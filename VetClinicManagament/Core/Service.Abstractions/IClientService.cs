using Domain.Models.Dtos;

namespace Contracts;

public interface IClientService
{
    Task<int> AddAnimalAsync(AddAnimalDto newAnimal);
    Task DeleteAnimalAsync(int animalId);
    Task<int> EditAnimalAsync(AddAnimalDto newAnimal);
    Task UpdatedAnimalAsync(int animalId, AnimalUpdateDto updatedAnimal);

    Task<int> AddBreedAsync(AddBreedDto newBreed);
    Task<int> AddColorAsync(AddColorDto newColor);
    Task<int> AddSpecieAsync(AddSpecieDto newSpecie);
}