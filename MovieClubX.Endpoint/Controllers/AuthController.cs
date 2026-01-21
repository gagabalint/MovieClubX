using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieClubX.Data.Helpers;
using MovieClubX.Entities.Dto.AuthDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieClubX.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IConfiguration configuration;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task Register([FromBody] UserCreateDto dto)
        {
            var user = new AppUser { Email = dto.Email, UserName = dto.Email, EmailConfirmed=true, GivenName=dto.GivenName, FamilyName= dto.FamilyName };
            await userManager.CreateAsync(user, dto.Password);
            if (userManager.Users.Count()==1)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginResultDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            if (user != null)
            {
                var isCorrect = await userManager.CheckPasswordAsync(user,dto.Password);
                if (isCorrect)
                {
                    var claim = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,user.UserName!),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    };
                    foreach (var role in await userManager.GetRolesAsync(user))
                    {
                        claim.Add(new Claim(ClaimTypes.Role, role));
                    }
                    int expiryInMinutes = int.Parse(configuration["jwt:expiry"] ?? throw new Exception("jwt:expiry not found in appsettings.json"));
                    var token = GenerateAccessToken(claim, expiryInMinutes);
                    return Ok(new LoginResultDto()
                    {
                        Token=new JwtSecurityTokenHandler().WriteToken(token),
                        Expiry=DateTime.UtcNow.AddMinutes(expiryInMinutes)
                    });
                
                }
                else
                {
                    return BadRequest("Incorrect password");

                }
            }
            else
            {
                return BadRequest("User not found");
            }
        }

        private JwtSecurityToken GenerateAccessToken(IEnumerable<Claim>? claims, int expiryInMinutes)
        {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"] ?? throw new Exception("jwt:key not found in appsettings.json")));
            return new JwtSecurityToken(
                  issuer: "movieclub.com",
                  audience: "movieclub.com",
                  claims: claims?.ToArray(),
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
        }
    }
}
