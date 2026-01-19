using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Entities.Dto.RateDtos
{
    public class RateCreateDto
    {
        public string? Text { get; set; } = string.Empty;
        public int Value { get; set; }
        public string MovieId { get; set; } = string.Empty;
    }
}
