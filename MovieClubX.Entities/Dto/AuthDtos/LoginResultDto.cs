using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Entities.Dto.AuthDtos
{
    public class LoginResultDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
    }
}
