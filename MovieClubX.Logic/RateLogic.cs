using AutoMapper;
using MovieClubX.Data;
using MovieClubX.Entities.Dto;
using MovieClubX.Entities.Entity;
using MovieClubX.Logic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClubX.Logic
{
    public class RateLogic
    {
        public Repository<Rate> repository;
        public Mapper mapper;

        public RateLogic(Repository<Rate> repository, DtoProvider dtoProvider)
        {
            this.repository = repository;
            this.mapper = dtoProvider.Mapper;
        }
        public async Task AddRateAsync( RateCreateDto dto)
        {
            await repository.CreateAsync(mapper.Map<Rate>(dto));

        }
    }
}
