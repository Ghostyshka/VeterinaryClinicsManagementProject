using Domain.Enum;

namespace Domain.Entities;

public class User
{
    private UserRole _userRole;

    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

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
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<UserAnimal> UserAnimals { get; set; } = new List<UserAnimal>();
}