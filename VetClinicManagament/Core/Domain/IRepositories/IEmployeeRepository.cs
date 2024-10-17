using Domain.Entities;

namespace Domain.Repositories;

public interface IEmployeeRepository
{
    Task AddEmployeeAsync(Employee employee);
    Task<Employee?> GetEmployeeByEmailAsync(string email);
}