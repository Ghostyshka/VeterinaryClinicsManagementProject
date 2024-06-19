using VetClinic.Domain.Enum;

namespace VetClinic.Domain.Models;

public class UserModel
{
    private UserRole _userRole;

    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username {  get => $"{FirstName} {LastName}"; set { } }
    public DateTime DateOfBirth { get; set; } // TO DO: implement happy birthday notifications

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
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}