using MovieClubX.Entities.Dto.RateDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Entities.Dto.MovieDtos
{
    public class MovieViewDto
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public IEnumerable<RateViewDto>? Rates { get; set; }
        public int TitleLength { get { return Title.Length; } }
    }
}
