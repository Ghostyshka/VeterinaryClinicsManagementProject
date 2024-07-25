using Contracts;
using Domain.Entities;
using Domain.Enum;
using Domain.Models.Dtos;
using Domain.Repositories;

namespace Service;

public class ClientService : IClientService
{
    private readonly IRepositoryManager _repositoryManager;

    public ClientService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }


    public async Task<int> AddAnimalAsync(AddAnimalDto newAnimal)
    {
        var worker = await _repositoryManager.UserRepository.GetUserByEmailAsync(newAnimal.WorkerEmail) ??
            throw new KeyNotFoundException("Worker not found");

        if (worker.UserRole != UserRole.ClinicWorker)
        {
            throw new UnauthorizedAccessException("Only workers can add animals");
        }

        var owner = await _repositoryManager.UserRepository.GetUserByEmailAsync(newAnimal.OwnerEmail) ??
            throw new KeyNotFoundException("Owner not found");

        var animal = new Animal
        {
            AnimalName = newAnimal.AnimalName,
            Species = newAnimal.Species,
            Age = newAnimal.Age,
            Breed = newAnimal.Breed,
            Color = newAnimal.Color,
            AnimalGender = newAnimal.AnimalGender,
            IsLive = newAnimal.IsLive,
            Vaccination = newAnimal.Vaccination,
            VaccineType = newAnimal.VaccineType,
            Weight = newAnimal.Weight,
        };

        await _repositoryManager.ClientRepository.AddAnimalAsync(animal);

        var userAnimal = new UserAnimal     //rewrite
        {
            UserId = owner.UserId,
            AnimalId = animal.AnimalId,
        };

        await _repositoryManager.ClientRepository.AddUserAnimalAsync(userAnimal);

        return animal.AnimalId;
    }

    public async Task<bool> AddVaccinationToAnimalAsync(AddVaccinationDto addVaccinationDto)
    {
        var vaccineType = new VaccineType
        {
            LiveAttenuated = addVaccinationDto.VaccineType.LiveAttenuated,
            Inactivated = addVaccinationDto.VaccineType.Inactivated,
            Toxoid = addVaccinationDto.VaccineType.Toxoid,
            Subunit = addVaccinationDto.VaccineType.Subunit,
            Recombinant = addVaccinationDto.VaccineType.Recombinant,
            Conjugate = addVaccinationDto.VaccineType.Conjugate,
            DNARNA = addVaccinationDto.VaccineType.DNARNA,
            Adjuvanted = addVaccinationDto.VaccineType.Adjuvanted,
            Multivalent = addVaccinationDto.VaccineType.Multivalent,
            Vector = addVaccinationDto.VaccineType.Vector,
        };

        var vaccine = new Vaccine
        {
            VaccineName = addVaccinationDto.Vaccine.VaccineName,
            Manufacturer = addVaccinationDto.Vaccine.Manufacturer,
            ExpiryDate = addVaccinationDto.Vaccine.ExpiryDate,
            VaccineType = vaccineType,
            AnimalId = addVaccinationDto.AnimalId
        };

        return await _repositoryManager.ClientRepository.AddVaccinationToAnimalAsync(vaccine);
    }
}