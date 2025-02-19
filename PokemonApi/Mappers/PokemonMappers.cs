using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers;


public static class PokemonMapper{

   public static Pokemon ToModel(this PokemonEntity entity){
    if(entity is null) {
        return null;
    }

    return new Pokemon
    {
        Id = entity.Id,
        Name = entity.Name,
        Type = entity.Type,
        Level = entity.Level,
        Stats = new Stats{
               Attack = entity.attack,
                Defense = entity.Defense,
                Speed = entity.Speed,
                Health = entity.Health
    },
   };
}
   public static PokemonResponseDto ToDto(this Pokemon pokemon){
    
           return new PokemonResponseDto
       {
           id = pokemon.Id,
           name = pokemon.Name,
           type = pokemon.Type,
           level = pokemon.Level,
           stats = new StatsDto
           {
               Attack = pokemon.Stats.Attack,
               Defense = pokemon.Stats.Defense,
               Speed = pokemon.Stats.Speed,
                Health = pokemon.Stats.Health

           }
       };
   }
}
