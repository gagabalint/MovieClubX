using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieClubX.Data;
using MovieClubX.Entities.Dto.MovieDtos;
using MovieClubX.Entities.Entity;
using MovieClubX.Logic;
using MovieClubX.Logic.Dto;
using System.Threading.Tasks;

namespace MovieClubX.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieLogic logic;
        
        public MovieController(MovieLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<MovieViewDto> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("Short")]
        public IEnumerable<MovieShortViewDto> GetShort()
        {
            return logic.ReadAllShort();
        }

        [HttpGet("{slug}")]
        public MovieViewDto Get(string slug)
        {
            return logic.ReadSlug(slug);
        }

        [HttpPost]
        public async Task Post([FromBody] MovieCreateUpdateDto dto)
        {
            await logic.Create(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {

            await logic.Delete(id);

        }

        [HttpPut("{id}")]
        public async Task Update(string id, [FromBody] MovieCreateUpdateDto dto)
        {
            await logic.Update(id, dto);
        }
    }
}
