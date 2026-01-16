using Microsoft.AspNetCore.Mvc;
using MovieClubX.Data;
using MovieClubX.Entities.Dto;
using MovieClubX.Entities.Entity;

namespace MovieClubX.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieClubContext ctx;
        public MovieController(MovieClubContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<MovieViewDto> Get() { return ctx.Movies.Select(i=> new MovieViewDto { Rate=i.Rate, Title=i.Title,Id=i.Id}); }

        [HttpPost]
        public void Post(MovieCreateUpdateDto dto)
        {
            var movie = new Movie { Rate=dto.Rate, Title=dto.Title};
            ctx.Movies.Add(movie);
            ctx.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var toDelete = ctx.Movies.FirstOrDefault(x => x.Id == id);
            if (toDelete != null)
            {
                ctx.Movies.Remove(toDelete);
                ctx.SaveChanges();
            }
        }

        [HttpPut("{id}") ]
        public void Update(string id, [FromBody]MovieCreateUpdateDto dto)
        {
            var toUpdate = ctx.Movies.FirstOrDefault(i => i.Id == id);
            if (toUpdate != null)
            {
                toUpdate.Title = dto.Title;
                toUpdate.Rate= dto.Rate;
                ctx.SaveChanges();
            }
        }
    }
}
