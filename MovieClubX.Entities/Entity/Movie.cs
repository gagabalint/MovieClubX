using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieClubX.Entities.Entity
{
    public class Movie
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [StringLength(250)]
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; }= string.Empty;
        public virtual ICollection<Rate>? Rates { get; set; }

    }
}
