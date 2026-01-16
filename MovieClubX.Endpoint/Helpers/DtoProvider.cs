using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using MovieClubX.Entities.Dto;
using MovieClubX.Entities.Entity;

namespace MovieClubX.Endpoint.Helpers
{
    public class DtoProvider
    {
        public Mapper Mapper { get; }
        public DtoProvider()
        {
            Mapper =new Mapper( new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MovieCreateUpdateDto, Movie>();
                cfg.CreateMap<Movie, MovieViewDto>();
            },NullLoggerFactory.Instance));
        }
    }
}
