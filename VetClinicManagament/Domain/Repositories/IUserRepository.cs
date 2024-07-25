using Domain.Entities;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<int> AddUserAsync(UserRegistrationDto newUser);
    Task<UserModel> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(int userId);
    Task<IActionResult> UpdateUserAsync(int userId, UserDto updatedUser);
    Task<IActionResult> DeleteUserAsync(int userId);
}