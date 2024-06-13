using VetClinic.Domain.Enum;

namespace VetClinic.Domain.Models.Dtos;

public class UserDto
{
    private UserRole _userRole;

    public static implicit operator UserDto(UserModel model)
    {
        return new UserDto
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = $"{model.FirstName} {model.LastName}",
            DateOfBirth = model.DateOfBirth,
            UserRole = model.UserRole,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Password = model.PasswordHash,
            CreatedAt = model.CreatedAt,
        };
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public UserRole UserRole
    {
        get => _userRole;
        set
        {
            if (!System.Enum.IsDefined(typeof(UserRole), value))
            {
                throw new ArgumentException("Invalid user role");
            }
            _userRole = value;
        }
    }

    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}