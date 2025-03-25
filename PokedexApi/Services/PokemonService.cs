using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Models;
using PokedexApi.Repositories;

namespace PokedexApi.Services;

public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonService(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository; 
    }

    public async Task<Pokemon?> GetPokemonById(Guid id, CancellationToken cancellationToken)
    {
        return await _pokemonRepository.GetPokemonByIdAsync (id, cancellationToken); 
    }

       public async Task<List<Pokemon>> GetPokemonByName(string name, CancellationToken cancellationToken)
    {
        var response = await _pokemonRepository.GetPokemonByNameAsync(name, cancellationToken);
        return response?.ToList() ?? new List<Pokemon>();
    }
    
    public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        return await _pokemonRepository.DeletePokemonByIdAsync(id, cancellationToken);
    }

    public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken){
        //
        return await _pokemonRepository.CreatePokemonAsync(pokemon, cancellationToken); 

    }
}
