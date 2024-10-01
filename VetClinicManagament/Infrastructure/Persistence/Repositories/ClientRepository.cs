using Domain.Entities;
using Domain.Models.Dtos;
using Domain.Repositories;
using Persistence.Data;

namespace Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly DataContext _dataContext;

    public ClientRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> AddAnimalAsync(Animal animal)
    {
        _dataContext.Animals.Add(animal);
        await _dataContext.SaveChangesAsync();
        return animal.AnimalId;
    }

    public async Task<int> AddBreedAsync(Breed breed)
    {
        _dataContext.Breed.Add(breed);
        await _dataContext.SaveChangesAsync();
        return breed.BreedId;
    }

    public async Task<int> AddColorAsync(Color color)
    {
        _dataContext.Color.Add(color);
        await _dataContext.SaveChangesAsync();
        return color.ColorId;
    }

    public async Task<int> AddSpeciesAsync(Specie specie)
    {
        _dataContext.Specie.Add(specie);
        await _dataContext.SaveChangesAsync();
        return specie.SpecieId;
    }

    public async Task<bool> AddUserAnimalAsync(AnimalOwner userAnimal)
    {
        _dataContext.AnimalOwner.Add(userAnimal);
        await _dataContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAnimalAsync(int animalId)
    {
        var animal = await _dataContext.Animals.FindAsync(animalId);
        if (animal == null)
        {
            return false;
        }

        _dataContext.Animals.Remove(animal);
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatedAnimalAsync(int animalId, AnimalUpdateDto updatedAnimal)
    {
        var animal = await _dataContext.Animals.FindAsync(animalId);
        if (animal == null)
        {
            return false;
        }

        // Only update fields that have values in the updatedAnimal object
        if (!string.IsNullOrEmpty(updatedAnimal.AnimalName))
        {
            animal.AnimalName = updatedAnimal.AnimalName;
        }if (updatedAnimal.SpeciesId.HasValue)  // Assuming SpeciesId is nullable int
        {
            animal.SpeciesId = updatedAnimal.SpeciesId.Value;
        }if (updatedAnimal.ColorId.HasValue)  // Assuming ColorId is nullable int
        {
            animal.ColorId = updatedAnimal.ColorId.Value;
        }if (updatedAnimal.BreedId.HasValue)  // Assuming BreedId is nullable int
        {
            animal.BreedId = updatedAnimal.BreedId.Value;
        }
        if (updatedAnimal.DateOfBirth.HasValue)
        {
            animal.DateOfBirth = updatedAnimal.DateOfBirth.Value;
        }if (updatedAnimal.AnimalGender.HasValue)
        {
            animal.AnimalGender = updatedAnimal.AnimalGender.Value;
        }if (updatedAnimal.IsLive != animal.IsLive)
        {
            animal.IsLive = updatedAnimal.IsLive;
        }if (updatedAnimal.Weight.HasValue)
        {
            animal.Weight = updatedAnimal.Weight.Value;
        }

        _dataContext.Animals.Update(animal);
        await _dataContext.SaveChangesAsync();
        return true;
    }
}