using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService authService,
        IConfiguration configuration,
        ILogger<AuthController> logger
    ) : base(configuration, logger)
    {
        _authService = authService;
    }

    [HttpPost("registerAsUser")]
    public async Task<IActionResult> RegisterAsUser(UserRegistrationDto newUser)
    {
        var result = await _authService.RegisterUserAsync(newUser);
        return result;
    }

    [HttpPost("registerAsEmployee")]
    public async Task<IActionResult> RegisterAsEmployee(EmployeeRegistrationDto newEmployee)
    {
        var result = await _authService.RegisterEmployeeAsync(newEmployee);
        return result;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(PersonLoginDto loggedUser)
    {
        var result = await _authService.LoginAsync(loggedUser);
        return result;
    }

    [HttpDelete("delete/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        await _authService.DeleteUserAsync(userId);
        return NoContent();
    }

    [HttpPut("update/{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, UserUpdateDto updatedUser)
    {
        await _authService.UpdateUserAsync(userId, updatedUser);
        return NoContent();
    }
}