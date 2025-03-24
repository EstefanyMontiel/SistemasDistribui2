using PokedexApi.Models; 
namespace PokedexApi.Services;

public interface IPokemonService
{ 
    Task<Pokemon?> GetPokemonByIdAsync (Guid id, CancellationToken cancellationToken); //metódo
    
    Task<List<Pokemon>> GetPokemonByName(string name, CancellationToken cancellationToken);
    Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);

}