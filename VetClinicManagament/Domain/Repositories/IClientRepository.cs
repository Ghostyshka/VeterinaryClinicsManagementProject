using Domain.Entities;

namespace Domain.Repositories;

public interface IClientRepository
{
    Task<int> AddAnimalAsync(Animal animal);
    Task<bool> AddUserAnimalAsync(UserAnimal userAnimal);
    Task<bool> AddVaccinationToAnimalAsync(Vaccine vaccine);
}