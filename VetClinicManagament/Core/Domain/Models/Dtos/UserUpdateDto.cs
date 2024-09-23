namespace Domain.Models.Dtos;

public class UserUpdateDto
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}