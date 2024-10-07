using Domain.Entities;

namespace Domain.Models.Dtos;

public class EmployeeRegistrationDto
{
    public static implicit operator EmployeeRegistrationDto(Employee model)
    {
        return new EmployeeRegistrationDto
        {
            FullName = model.EmployeeFullName,
            DateOfBirth = model.DataOfBirth,
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