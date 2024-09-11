namespace Domain.Entities;

public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeFullName { get; set; }
    public DateTime DataOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Visit> Visit { get; set; }
}