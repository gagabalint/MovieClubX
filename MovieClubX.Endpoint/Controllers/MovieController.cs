using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieClubX.Data;
using MovieClubX.Data.Helpers;
using MovieClubX.Entities.Dto.MovieDtos;
using MovieClubX.Entities.Entity;
using MovieClubX.Logic;
using MovieClubX.Logic.Dto;
using System.Threading.Tasks;

namespace MovieClubX.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieLogic logic;
        UserManager<AppUser> userManager;

        public MovieController(MovieLogic logic, UserManager<AppUser> userManager)
        {
            this.logic = logic;
            this.userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<MovieViewDto> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("Short")]
        public IEnumerable<MovieShortViewDto> GetShort()
        {
            return logic.ReadAllShort();
        }

        [HttpGet("{slug}")]
        public MovieViewDto Get(string slug)
        {
            return logic.ReadSlug(slug);
        }

        [HttpPost]
        [Authorize]
        public async Task Post([FromBody] MovieCreateUpdateDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            await logic.Create(dto, user!.Id);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {

            await logic.Delete(id);

        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task Update(string id, [FromBody] MovieCreateUpdateDto dto)
        {
            var user = await userManager.GetUserAsync(User);

            await logic.Update(id, dto, user!.Id);
        }
    }
}
