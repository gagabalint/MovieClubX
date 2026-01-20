using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Entities.Dto.RateDtos
{
    public class RateCreateDto
    {
        public string? Text { get; set; } = string.Empty;
        [Range(1,10)]
        public int Value { get; set; }
        [Required]
        [MinLength(3)]
        public string MovieId { get; set; } = string.Empty;
    }
}
