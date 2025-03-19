using PokedexApi.Models;

namespace PokedexApi.Repositories;

public interface IPokemonRepository{
    Task<Pokemon?> GetPokemonByIdAsync(Guid Id, CancellationToken cancellationToken); 
}

