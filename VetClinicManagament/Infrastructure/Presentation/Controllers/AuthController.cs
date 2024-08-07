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

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegistrationDto newUser)
    {
        var result = await _authService.RegisterUserAsync(newUser);
        return result;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto loggedUser)
    {
        var result = await _authService.LoginUserAsync(loggedUser);
        return result;
    }

    [HttpDelete("delete/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        await _authService.DeleteUserAsync(userId);
        return NoContent();
    }

    [HttpPut("update/{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, UserDto updatedUser)
    {
        await _authService.UpdateUserAsync(userId, updatedUser);
        return NoContent();
    }
}