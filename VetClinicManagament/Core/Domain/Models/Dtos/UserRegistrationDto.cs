using Domain.Entities;

namespace Domain.Models.Dtos;

public class UserRegistrationDto
{
    public static implicit operator UserRegistrationDto(User model)
    {
        return new UserRegistrationDto
        {
            FullName = model.FullName,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Password = model.Password,
        };
    }

    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}