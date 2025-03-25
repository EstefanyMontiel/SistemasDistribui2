using PokedexApi.Dtos;
using PokedexApi.Infrastructure.Soap.Dtos;
using PokedexApi.Models;

namespace PokedexApi.Mappers;

public static class PokemonMapper
{
public static PokemonResponse ToDto(this Pokemon pokemon){

    return new PokemonResponse{
        Id = pokemon.Id,
        Name = pokemon.Name,
        Type = pokemon.Type,
        Level = pokemon.Level, 
        Stats = new StatsResponse{
            Attack = pokemon.Attack,
            Defense = pokemon.Defense,
            Speed = pokemon.Speed
        }

        }; 
}

public static Pokemon ToModel(this PokemonResponseDto pokemon){

     return new Pokemon {
        Id = pokemon.Id,
        Name = pokemon.Name,
        Type = pokemon.Type,
        Level = pokemon.Level, 
            Attack = pokemon.Stats.Attack,
            Defense = pokemon.Stats.Defense,
            Speed = pokemon.Stats.Speed

        }; 
}

public static Pokemon ToModel(this CreatePokemonRequest pokemon){
return new Pokemon {
    Name = pokemon.Name,
    Type = pokemon.Type, 
    Level = pokemon.Level,
    Attack = pokemon.Attack,
    Defense = pokemon.Defense,
    Speed = pokemon.Speed 

};
}

public static CreatePokemonDto ToSoapDto(this Pokemon pokemon){
    return new CreatePokemonDto{
         Name = pokemon.Name,
    Type = pokemon.Type, 
    Level = pokemon.Level,
    Stats = new StatsDto{
    Attack = pokemon.Attack,
    Defense = pokemon.Defense,
    Speed = pokemon.Speed 
    }
}; 
}

}