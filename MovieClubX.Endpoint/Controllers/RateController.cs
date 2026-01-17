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
    public class RateController:ControllerBase
    {
        Repository<Rate> repository;
        Mapper mapper;
        public RateController(Repository<Rate> repository, DtoProvider provider)
        {
            this.repository = repository;
            mapper = provider.Mapper;
        }


        [HttpPost]
        public async Task AddRate( [FromBody] RateCreateDto dto)
        {
           await repository.CreateAsync(mapper.Map<Rate>(dto));
            
        }
    }
}
