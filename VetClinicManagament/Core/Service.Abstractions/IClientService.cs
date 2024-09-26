using Domain.Models.Dtos;

namespace Contracts;

public interface IClientService
{
    Task<int> AddAnimalAsync(AddAnimalDto newAnimal);
    Task<int> DeleteAnimalAsync(AddAnimalDto newAnimal);
    Task<int> EditAnimalAsync(AddAnimalDto newAnimal);

    Task<int> AddBreedAsync(AddBreedDto newBreed);
    Task<int> AddColorAsync(AddColorDto newColor);
    Task<int> AddSpecieAsync(AddSpecieDto newSpecie);
}