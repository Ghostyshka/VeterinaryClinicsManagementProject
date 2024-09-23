using Domain.Enum;

namespace Domain.Models.Dtos;

public class EmployeeDto
{
    public static implicit operator EmployeeDto(EmployeeModel model)
    {
        return new EmployeeDto
        {
            FullName = model.FullName,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Password = model.PasswordHash,
            CreatedAt = model.CreatedAt,
        };
    }

    public int UserId { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
}