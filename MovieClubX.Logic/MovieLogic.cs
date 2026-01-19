using AutoMapper;
using MovieClubX.Data;
using MovieClubX.Data.Helpers;
using MovieClubX.Entities.Dto.MovieDtos;
using MovieClubX.Entities.Entity;
using MovieClubX.Logic.Dto;

namespace MovieClubX.Logic
{
    public class MovieLogic
    {
        public Repository<Movie> repository;
        public Mapper mapper;

        public MovieLogic(Repository<Movie> repository, DtoProvider dtoProvider)
        {
            this.repository = repository;
            this.mapper = dtoProvider.Mapper;
        }
        public IEnumerable<MovieViewDto> ReadAll()
        {
            return repository.GetAll().Select(i => mapper.Map<MovieViewDto>(i));
        }

        public IEnumerable<MovieShortViewDto> ReadAllShort()
        {
            return repository.GetAll().Select(t => mapper.Map<MovieShortViewDto>(t));
        }

        public MovieViewDto ReadSlug(string slug)
        {
            return mapper.Map<MovieViewDto>(repository.GetAll().FirstOrDefault(i => i.Slug == slug));
        }

        public async Task Create( MovieCreateUpdateDto dto, string creatorId)
        {
            var movie = mapper.Map<Movie>(dto);
            movie.CreatorId = creatorId;
            //movie.Slug = SlugGenerator.SlugGenerator.GenerateSlug(dto.Title);

            await repository.CreateAsync(movie);
        }

        public async Task Delete(string id)
        {

            await repository.DeleteAsync(id);

        }

        public async Task Update(string id, MovieCreateUpdateDto dto, string creatorId)
        {
            var toUpdate = repository.GetById(id);
            if (toUpdate != null&&toUpdate.CreatorId==creatorId)
            {
                mapper.Map(dto, toUpdate);// same as adding these aswell: ,typeof(MovieCreateUpdateDto),typeof(Movie));


                await repository.UpdateAsync(toUpdate);
            }
        }
    }
}
