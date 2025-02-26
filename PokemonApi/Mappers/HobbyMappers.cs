using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers
{
    public static class HobbyMappers
    {
        public static HobbyEntity ToEntity(this Hobby model)
        {
            return new HobbyEntity
            {
                Id = model.Id,
                Name = model.Name,
                Top = model.Top
            };
        }

        public static Hobby ToModel(this HobbyEntity entity)
        {
            if(entity is null) {
             return null;
             }
            return new Hobby
            {
                Id = entity.Id,
                Name = entity.Name,
                Top = entity.Top
            };
        }

        public static HobbiesResponseDto ToDto(this Hobby model)
        {
            return new HobbiesResponseDto
            {
                Id = model.Id,
                Name = model.Name,
                Top = model.Top
            };
        }
    }
}