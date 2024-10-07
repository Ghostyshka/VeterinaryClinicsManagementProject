using BCrypt.Net;
using Contracts;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Service;

public class PersonService : IPersonService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMailService _mailService;

    public PersonService(IRepositoryManager repositoryManager, IMailService mailService)
    {
        _repositoryManager = repositoryManager;
        _mailService = mailService;
    }

    public async Task<IActionResult> RegisterPersonAsync<T>(T newPerson) where T : class, IPerson
    {
        if (newPerson is User user) // Type check for additional processing if needed
        {
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password, HashType.SHA512);
            await _repositoryManager.UserRepository.AddUserAsync(user);
        }
        else if (newPerson is Employee employee) // Similar check for Employee
        {
            employee.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(employee.Password, HashType.SHA512);
            await _repositoryManager.EmployeeRepository.AddEmployeeAsync(employee);
        }

        var existingPerson = await _repositoryManager.PersonRepository.GetPersonByEmailAsync<IPerson>(newPerson.Email);
        if (existingPerson != null)
        {
            await _mailService.SendWelcomeEmailAsync(existingPerson.Email, existingPerson.FullName);
        }

        return new OkObjectResult(newPerson);
    }
}