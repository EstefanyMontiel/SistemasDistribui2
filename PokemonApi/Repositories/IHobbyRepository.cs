
 
 using System.Globalization;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

    public interface IHobbyRepository
    {
     Task<Hobby> GetHobbyIdAsync (int id,CancellationToken cancellationToken);
     Task DeleteHobbyAsync (Hobby hobby, CancellationToken cancellationToken);
     Task <List<Hobby>> GetHobbiesByNamedAsync(string name, CancellationToken cancellationToken);
     
    }
    //localhost:PUERto/api/v1/pokemons/PONER_ID
    //https://localhost:7241/api/v1/pokemons/ 550e8400-e29b-41d4-a716-446655440001