using Contracts;
using Domain.Exceptions;
using Domain.Models;
using Domain.Models.Dtos;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Service;

public class AuthService : IAuthService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMailService _mailService;
    private IConfiguration _configuration;

    public AuthService(IConfiguration configuration, IRepositoryManager repositoryManager, IMailService mailService)
    {
        _configuration = configuration;
        _repositoryManager = repositoryManager;
        _mailService = mailService;
    }

    public async Task<IActionResult> RegisterUserAsync(UserRegistrationDto newUser)
    {
        newUser.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(newUser.Password, BCrypt.Net.HashType.SHA512);

        await _repositoryManager.UserRepository.AddUserAsync(newUser);

        var existingUser = await _repositoryManager.UserRepository.GetPersonByEmailAsync(newUser.Email);
        if (existingUser != null)
        {
            await _mailService.SendWelcomeEmailAsync(existingUser.Email, existingUser.FullName);
        }

        return new OkObjectResult(newUser);
    }

    public async Task<IActionResult> RegisterEmployeeAsync(EmployeeRegistrationDto newEmployee)
    {
        newEmployee.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(newEmployee.Password, BCrypt.Net.HashType.SHA512);

        await _repositoryManager.UserRepository.AddEmployeeAsync(newEmployee);

        var existingUser = await _repositoryManager.UserRepository.GetPersonByEmailAsync(newEmployee.Email);
        if (existingUser != null)
        {
            await _mailService.SendWelcomeEmailAsync(existingUser.Email, existingUser.FullName);
        }

        return new OkObjectResult(newEmployee);
    }

    private async Task<PersonModel> GetUserOrEmployee(string email)
    {
        var user = await _repositoryManager.UserRepository.GetPersonByEmailAsync(email);
        if (user != null)
        {
            return user;
        }

        return await _repositoryManager.UserRepository.GetPersonByEmailAsync(email);
    }

    public async Task<IActionResult> LoginAsync(PersonLoginDto loggedUser)
    {
        var existingUser = await _repositoryManager.UserRepository.GetPersonByEmailAsync(loggedUser.PersonEmail);

        if (existingUser == null)
        {
            throw new UserNotFoundException("User or Employee does not exist!");
        }

        if (!BCrypt.Net.BCrypt.EnhancedVerify(loggedUser.Password, existingUser.Password, BCrypt.Net.HashType.SHA512))
        {
            return new BadRequestObjectResult("Username or password are wrong");
        }

        JwtToken jwtToken = new(_configuration);
        string token = jwtToken.CreateToken(existingUser);

        return new OkObjectResult(token);
    }

    public async Task DeleteUserAsync(int userId)
    {
        await _repositoryManager.UserRepository.DeleteUserAsync(userId);
    }

    public async Task UpdateUserAsync(int userId, UserUpdateDto updatedUser)
    {
        await _repositoryManager.UserRepository.UpdateUserAsync(userId, updatedUser);
    }
}