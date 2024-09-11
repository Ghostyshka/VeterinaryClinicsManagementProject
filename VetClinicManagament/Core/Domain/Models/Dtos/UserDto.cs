using Domain.Enum;

namespace Domain.Models.Dtos;

public class UserDto
{
    public static implicit operator UserDto(UserModel model)
    {
        return new UserDto
        {
            FirstName = model.FullName,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Password = model.PasswordHash,
            CreatedAt = model.CreatedAt,
        };
    }

    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}