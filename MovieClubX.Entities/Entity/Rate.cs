using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Entities.Entity
{
    public class Rate
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Text { get; set; } = string.Empty;
        public int Value { get; set; }
        public string MovieId { get; set; } = string.Empty;

        [NotMapped]
        public virtual Movie? Movie{ get; set; }
    }
}
