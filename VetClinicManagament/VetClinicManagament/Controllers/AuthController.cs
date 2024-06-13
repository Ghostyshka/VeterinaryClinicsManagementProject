using Microsoft.AspNetCore.Mvc;
using VetClinic.Core.IRepository;
using VetClinic.Domain.Models.Dtos;
using VetClinic.Core.Services;
using VetClinic.Api.Controllers.BaseController;

namespace VetClinicManagament.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IUserRepository _userRepository;

    public AuthController(
        ILogger<AuthController> logger, 
        IUserRepository userRepository,
        IConfiguration configuration
        ) : base(configuration, logger)
    {
        _userRepository = userRepository;
    }


    [HttpPost("register")]
    public async Task<IActionResult> AddUser(UserDto newUser)
    {
        newUser.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(newUser.Password);

        await _userRepository.AddUserAsync(newUser);

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLoginDto loggedUser)
    {
        var existingUser = await _userRepository.GetUserByUsernameAsync(loggedUser.UserName);

        if (existingUser == null)
        {
            return BadRequest("UserName or password are wrong");
        }
        if (!BCrypt.Net.BCrypt.EnhancedVerify(loggedUser.Password, existingUser.PasswordHash))
        {
            return BadRequest("UserName or password are wrong");
        }

        JwtToken jwtToken = new(_configuration);
        string token = jwtToken.CreateToken(existingUser);

        return Ok(token);
    }
}