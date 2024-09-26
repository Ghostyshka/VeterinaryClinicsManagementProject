using Domain.Entities;

namespace Domain.Repositories;

public interface IClientRepository
{
    Task<int> AddAnimalAsync(Animal animal);
    Task<bool> AddUserAnimalAsync(AnimalOwner userAnimal);

    Task<int> AddBreedAsync(Breed breed);
    Task<int> AddSpeciesAsync(Specie specie);
    Task<int> AddColorAsync(Color color);
}