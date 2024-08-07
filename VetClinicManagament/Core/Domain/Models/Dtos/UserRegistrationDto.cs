using Domain.Enum;

namespace Domain.Models.Dtos;

public class UserRegistrationDto
{
    private UserRole _userRole;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
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
}