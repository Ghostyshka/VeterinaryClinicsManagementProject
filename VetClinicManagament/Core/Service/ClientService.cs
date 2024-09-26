using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Models.Dtos;
using Domain.Repositories;

namespace Service;

public class ClientService : IClientService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;


    public ClientService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<int> AddBreedAsync(AddBreedDto newBreed)
    {
        var breed = _mapper.Map<Breed>(newBreed);
        await _repositoryManager.ClientRepository.AddBreedAsync(breed);
        return breed.BreedId;
    }

    public async Task<int> AddColorAsync(AddColorDto newColor)
    {
        var color = _mapper.Map<Color>(newColor);
        await _repositoryManager.ClientRepository.AddColorAsync(color);
        return color.ColorId;
    }

    public async Task<int> AddSpecieAsync(AddSpecieDto newSpecie)
    {
        var species = _mapper.Map<Specie>(newSpecie);
        await _repositoryManager.ClientRepository.AddSpeciesAsync(species);
        return species.SpecieId;
    }

    public async Task<int> AddAnimalAsync(AddAnimalDto newAnimal)
    {
        var employee = await _repositoryManager.UserRepository.GetPersonByEmailAsync(newAnimal.EmployeeEmail) ??
           throw new KeyNotFoundException("Worker not found");

        var owner = await _repositoryManager.UserRepository.GetPersonByEmailAsync(newAnimal.UserEmail) ??
            throw new KeyNotFoundException("Owner not found");

        var animal = new Animal
        {
            AnimalName = newAnimal.AnimalName,
            DateOfBirth = newAnimal.DateOfBirth,
            AnimalGender = newAnimal.AnimalGender,
            IsLive = newAnimal.IsLive,
            Weight = newAnimal.Weight,
            SpeciesId = newAnimal.SpeciesId,
            ColorId = newAnimal.ColorId,
            BreedId = newAnimal.BreedId
        };
        await _repositoryManager.ClientRepository.AddAnimalAsync(animal);
        return animal.AnimalId;
    }

    //public async Task<int> DeleteAnimalAsync(AddAnimalDto newAnimal)
    //{
    //    return 1;
    //}
    //public async Task<int> EditAnimalAsync(AddAnimalDto newAnimal)
    //{
    //    return 1;
    //}
}