using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Entities.Dto.MovieDtos
{
    public class MovieCreateUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }
}
