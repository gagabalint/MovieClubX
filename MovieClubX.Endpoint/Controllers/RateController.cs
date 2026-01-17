using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieClubX.Data;
using MovieClubX.Entities.Dto;
using MovieClubX.Entities.Entity;
using MovieClubX.Logic;
using System.Threading.Tasks;

namespace MovieClubX.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController:ControllerBase
    {
        RateLogic logic;

        
        public RateController(RateLogic logic)
        {
            this.logic = logic;
        }


        [HttpPost]
        public async Task AddRate( [FromBody] RateCreateDto dto)
        {
           await logic.AddRateAsync(dto);
            
        }
    }
}
