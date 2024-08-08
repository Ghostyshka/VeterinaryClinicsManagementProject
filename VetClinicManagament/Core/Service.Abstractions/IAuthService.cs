﻿using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Contracts;

public interface IAuthService
{
    Task<IActionResult> RegisterUserAsync(UserRegistrationDto newUser);

    Task<IActionResult> LoginUserAsync(UserLoginDto loggedUser);

    Task DeleteUserAsync(int userId);

    Task UpdateUserAsync(int userId, UserDto updatedUser);
}