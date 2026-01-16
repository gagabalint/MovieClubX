using Microsoft.EntityFrameworkCore;
using MovieClubX.Entities.Entity;

namespace MovieClubX.Data
{
    public class MovieClubContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieClubContext(DbContextOptions<MovieClubContext> opt):base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>().HasOne(m => m.Movie).WithMany(r => r.Rates).HasForeignKey(f => f.MovieId).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
