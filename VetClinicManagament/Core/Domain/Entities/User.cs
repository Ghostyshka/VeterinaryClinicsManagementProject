namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; }

    public DateTime DateOfBirth { get; set; } // TO DO: implement happy birthday notifications

    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Visit> Visit { get; set; }
    public ICollection<AnimalOwner> AnimalOwner { get; set; }
}