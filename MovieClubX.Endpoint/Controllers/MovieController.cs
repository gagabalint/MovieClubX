using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieClubX.Data;
using MovieClubX.Endpoint.Helpers;
using MovieClubX.Entities.Dto;
using MovieClubX.Entities.Entity;
using System.Threading.Tasks;

namespace MovieClubX.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        Repository<Movie> repository;
        Mapper mapper;
        public MovieController(Repository<Movie> repository, DtoProvider mapper)
        {
            this.repository = repository;
            this.mapper = mapper.Mapper;
        }

        [HttpGet]
        public IEnumerable<MovieViewDto> Get() {
            return  repository.GetAll().Select(i=>mapper.Map<MovieViewDto>(i));
        }

        [HttpGet("Short")]
        public IEnumerable<MovieShortViewDto> GetShort() {
            return repository.GetAll().Select(t => mapper.Map<MovieShortViewDto>(t));
        }

        [HttpGet("{slug}")]
        public MovieViewDto Get(string slug)
        {
            return mapper.Map<MovieViewDto>( repository.GetAll().FirstOrDefault(i => i.Slug == slug));
        }

        [HttpPost]
        public async Task Post([FromBody]MovieCreateUpdateDto dto)
        {
            var movie = mapper.Map<Movie>(dto);
            //movie.Slug = SlugGenerator.SlugGenerator.GenerateSlug(dto.Title);
            
         await   repository.CreateAsync(movie);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
           
               await repository.DeleteAsync(id);
            
        }

        [HttpPut("{id}") ]
        public async Task Update(string id, [FromBody]MovieCreateUpdateDto dto)
        {
            var toUpdate = repository.GetById(id);
            if (toUpdate != null)
            {
                mapper.Map(dto, toUpdate);// same as adding these aswell: ,typeof(MovieCreateUpdateDto),typeof(Movie));


               await repository.UpdateAsync(toUpdate);
            }
        }
    }
}
