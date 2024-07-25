using Microsoft.AspNetCore.Http.HttpResults;
using VetClinic.Core.IRepository;
using VetClinic.Domain.Data;
using VetClinic.Domain.Entity;
using VetClinic.Domain.Models.Dtos;

namespace VetClinic.Core.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly DataContext _dataContext;

    public ClientRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> AddAnimalAsync(AnimalDto newAnimal)
    {
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
            Weight = newAnimal.Weight
        };

        _dataContext.Animals.Add(animal);
        await _dataContext.SaveChangesAsync();

        var userAnimal = new UserAnimal
        {
            UserId = newAnimal.OwnerId,
            AnimalId = animal.AnimalId
        };

        _dataContext.UserAnimals.Add(userAnimal);
        await _dataContext.SaveChangesAsync();

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

        _dataContext.VaccinesType.Add(vaccineType);
        _dataContext.Vaccine.Add(vaccine);

        var result = await _dataContext.SaveChangesAsync();

        return result > 0;
    }

    public void Dispose()
    {
        _dataContext?.Dispose();
    }
}