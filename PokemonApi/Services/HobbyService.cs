using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Models;
using PokemonApi.Repositories;
namespace PokemonApi.Services;

 public class HobbyService : IHobbyService
{
      private readonly IHobbyRepository _hobbyRepository; 
      public HobbyService(IHobbyRepository hobbyRepository)
    {
         _hobbyRepository = hobbyRepository;
    }

      public async Task<HobbiesResponseDto> GetHobbyById(int id, CancellationToken cancellationToken){
         var hobby = await _hobbyRepository.GetHobbyIdAsync(id, cancellationToken);
         if (hobby == null){
             throw new FaultException("hobby not found");
        }
         return hobby.ToDto();      
    }

     public async Task<bool> DeleteHobby(int id, CancellationToken cancellationToken){
         var hobby = await _hobbyRepository.GetHobbyIdAsync(id, cancellationToken);
         if(hobby is null){
             throw new FaultException("Hobby not found");
        }
         await _hobbyRepository.DeleteHobbyAsync(hobby, cancellationToken);
         return true;
    }

     public async Task<List<HobbiesResponseDto>> GetHobbiesByName(string name, CancellationToken cancellationToken){
         var hobbies = await _hobbyRepository.GetHobbiesByNamedAsync(name, cancellationToken);
 
         if (hobbies == null || !hobbies.Any())
        {
             return new List<HobbiesResponseDto>();
        }
         return hobbies.Select(s => s.ToDto()).ToList();
    }

}
