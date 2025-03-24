using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Dtos;
using PokedexApi.Models;

namespace PokedexApi.Infrastructure.Soap.Contracts;


    [ServiceContract(Name = "PokemonService", Namespace ="http://pokemon-api/pokemon-service")]

    public interface IPokemonService
    {
     
     [OperationContract]
     Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken); //metodo que se va a exponer
    [OperationContract]
    Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken); //metodo que se va a exponer
     
     [OperationContract]
        Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken);
        
     [OperationContract]
        Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto, CancellationToken cancellationToken);
    [OperationContract]
    Task<List<PokemonResponseDto>> GetPokemonByName(string name,CancellationToken cancellationToken);
    [OperationContract ]
    Task<bool> DeletePokemonById(Guid id, CancellationToken cancellationToken);

         [OperationContract]
        Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto updatePokemonDto, CancellationToken cancellationToken);
    Task GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);
    [OperationContract]
    Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto,CancellationToken cancellationToken);

    [OperationContract]
    Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon,CancellationToken cancellationToken);
    
}