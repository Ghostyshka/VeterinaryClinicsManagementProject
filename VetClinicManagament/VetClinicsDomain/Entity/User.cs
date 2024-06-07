namespace VetClinicsDomain.Entity;

public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int DateOfBirth { get; set; }                // TO DO: implement happy birthday notifications

    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}