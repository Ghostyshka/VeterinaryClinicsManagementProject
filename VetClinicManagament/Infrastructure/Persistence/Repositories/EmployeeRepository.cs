using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _dataContext;

    public EmployeeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _dataContext.Employees.AddAsync(employee);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Employee?> GetEmployeeByEmailAsync(string email)
    {
        return await _dataContext.Employees.FirstOrDefaultAsync(x => x.Email == email);
    }
}