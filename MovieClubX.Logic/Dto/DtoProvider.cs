using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using MovieClubX.Entities.Dto.MovieDtos;
using MovieClubX.Entities.Dto.RateDtos;
using MovieClubX.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Logic.Dto
{
    public class DtoProvider
    {
        public Mapper Mapper { get; }
        public DtoProvider()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MovieCreateUpdateDto, Movie>().AfterMap((src, dst) => dst.Slug = SlugGenerator.SlugGenerator.GenerateSlug(src.Title));
                cfg.CreateMap<Movie, MovieViewDto>();
                cfg.CreateMap<Movie, MovieShortViewDto>().AfterMap((src, dest) => dest.AvgRate = src?.Rates?.Count > 0 ? src.Rates.Average(r => r.Value) : 0);
                cfg.CreateMap<RateCreateDto, Rate>();
                cfg.CreateMap<Rate, RateViewDto>();
            }, NullLoggerFactory.Instance));
        }
    }
}
