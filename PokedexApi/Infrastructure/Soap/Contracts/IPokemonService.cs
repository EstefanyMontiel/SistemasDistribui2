using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Dtos;

namespace PokedexApi.Infrastructure.Soap.Contracts;


    [ServiceContract(Name = "PokemonService", Namespace ="http://pokemon-api/pokemon-service")]

    public interface IPokemonService
    {
     
     [OperationContract]
     Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken); //metodo que se va a exponer
     
     [OperationContract]
        Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken);
        
     [OperationContract]
        Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto, CancellationToken cancellationToken);

         [OperationContract]
        Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto updatePokemonDto, CancellationToken cancellationToken);
    Task GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);
}