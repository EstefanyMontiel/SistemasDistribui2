
using System.Globalization;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

    public interface IHobbyRepository
    {
    Task<Hobby> GetHobbyIdAsync (int id,CancellationToken cancellationToken);
    Task DeleteHobbyAsync (Hobby hobby, CancellationToken cancellationToken);
    Task <List<Hobby>> GetHobbiesByNamedAsync(string name, CancellationToken cancellationToken);

    }
