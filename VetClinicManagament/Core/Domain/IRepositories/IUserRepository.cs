﻿using Domain.Entities;
using Domain.Models;
using Domain.Models.Dtos;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<int> AddUserAsync(UserRegistrationDto newUser);
    Task<int> AddEmployeeAsync(EmployeeRegistrationDto newEmployee);

    Task<PersonModel> GetPersonByEmailAsync(string email);
    Task<User> GetUserByIdAsync(int userId);

    Task<bool> UpdateUserAsync(int userId, UserUpdateDto updatedUser);
    Task<bool> DeleteUserAsync(int userId);
}