using VetClinic.Domain.Models.Dtos;

namespace VetClinic.Core.IRepository;

public interface IClientRepository
{
    Task<int> AddAnimalAsync(AnimalDto newAnimal);
    Task<bool> AddVaccinationToAnimalAsync(AddVaccinationDto addVaccinationDto);
}