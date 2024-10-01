using Domain.Entities;
using Domain.Models;
using Domain.Models.Dtos;
using Domain.Repositories;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Enum;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> AddUserAsync(UserRegistrationDto newUser)
    {
        var user = new User
        {
            FullName = newUser.FullName,
            PhoneNumber = newUser.PhoneNumber,
            Password = newUser.Password,
            Email = newUser.Email,
            DateOfBirth = newUser.DateOfBirth,
        };

        _dataContext.Users.Add(user);
        await _dataContext.SaveChangesAsync();
        return user.UserId;
    }

    public async Task<int> AddEmployeeAsync(EmployeeRegistrationDto newEmployee)
    {
        var employee = new Employee
        {
            EmployeeFullName = newEmployee.FullName,
            PhoneNumber = newEmployee.PhoneNumber,
            Password = newEmployee.Password,
            Email = newEmployee.Email,
            DataOfBirth = newEmployee.DateOfBirth,
        };

        _dataContext.Employees.Add(employee);
        await _dataContext.SaveChangesAsync();
        return employee.EmployeeId;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var user = await _dataContext.Users.FindAsync(userId);
        if (user == null)
        {
            return false;
        }

        _dataContext.Users.Remove(user);
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<PersonModel> GetPersonByEmailAsync(string email)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(email);

        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        if (user != null)
        {
            return new UserModel()
            {
                Id = user.UserId,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                CreatedAt = DateTime.UtcNow,
            };
        }

        var employee = await _dataContext.Employees.FirstOrDefaultAsync(e => e.Email.Equals(email));
        if (employee != null)
        {
            return new EmployeeModel()
            {
                Id = employee.EmployeeId,
                FullName = employee.EmployeeFullName,
                DateOfBirth = employee.DataOfBirth,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Password = employee.Password,
                CreatedAt = DateTime.UtcNow,
            };
        }

        return null;
    }

    public async Task<EmployeeModel> GetEmployeeByEmailAsync(string email)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(email);

        var employee = await _dataContext.Employees
            .FirstOrDefaultAsync(u => u.Email.Equals(email));

        return new EmployeeModel
        {
            EmployeeId = employee.EmployeeId,
            FullName = employee.EmployeeFullName,
            Email = employee.Email,
            PasswordHash = employee.Password,
            PhoneNumber = employee.PhoneNumber
        };
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _dataContext.Users.FindAsync(userId);
    }

    public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
    {
        return await _dataContext.Employees.FindAsync(employeeId);
    }

    public async Task<bool> UpdateUserAsync(int userId, UserUpdateDto updatedUser)
    {
        var user = await _dataContext.Users.FindAsync(userId);
        if (user == null)
        {
            return false;
        }

        // Only update fields that have values in the updatedUser object
        if (!string.IsNullOrEmpty(updatedUser.FullName))
        {
            user.FullName = updatedUser.FullName;
        }
        if (!string.IsNullOrEmpty(updatedUser.Email))
        {
            user.Email = updatedUser.Email;
        }
        if (!string.IsNullOrEmpty(updatedUser.PhoneNumber))
        {
            user.PhoneNumber = updatedUser.PhoneNumber;
        }
        if (!string.IsNullOrEmpty(updatedUser.Password))
        {
            user.Password = updatedUser.Password;
        }

        _dataContext.Users.Update(user);
        await _dataContext.SaveChangesAsync();
        return true;
    }
}