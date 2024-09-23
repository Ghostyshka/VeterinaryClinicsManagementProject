namespace Domain.Interfaces;

public interface IPerson        // TO:DO for all types users 
{
    int Id { get; set; }
    string FullName { get; set; }
    DateTime DateOfBirth { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string Password { get; set; }
    DateTime CreatedAt { get; set; }
}