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

    public async Task<bool> AddUserAnimalAsync(AnimalOwner userAnimal)
    {
        _dataContext.UserAnimals.Add(userAnimal);
        await _dataContext.SaveChangesAsync();

        return true;
    }
}