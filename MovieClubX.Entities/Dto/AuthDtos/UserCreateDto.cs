using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Entities.Dto.AuthDtos
{
    public class UserCreateDto
    {
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required string FamilyName { get; set; } = string.Empty;
        public required string GivenName { get; set; } = string.Empty;
    }
}
