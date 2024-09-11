using Domain.Enum;

namespace Domain.Entities;

public class User
{

    public int UserId { get; set; }
    public string FullName { get; set; }

    public DateTime DateOfBirth { get; set; } // TO DO: implement happy birthday notifications

    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    //public ICollection<UserAnimal> UserAnimals { get; set; } = new List<UserAnimal>();
    //public ICollection<Order> Orders { get; set; } = new List<Order>();
}