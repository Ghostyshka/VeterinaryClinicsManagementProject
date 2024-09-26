using Domain.Entities;
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
}