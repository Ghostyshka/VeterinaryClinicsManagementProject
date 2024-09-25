using Domain.Entities;
using Domain.Models;
using Domain.Models.Dtos;
using Domain.Repositories;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;

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

    public async Task<UserModel> GetUserByEmailAsync(string email)
    {
        var user = await _dataContext.Users
            .FirstOrDefaultAsync(u => u.Email.Equals(email));

        if (email == null)
        {
            return null;        // to:do warning
        }

        return new UserModel
        {
            UserId = user.UserId,
            FullName = user.FullName,
            Email = user.Email,
            PasswordHash = user.Password,
            PhoneNumber = user.PhoneNumber
        };
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _dataContext.Users.FindAsync(userId);
    }

    //public async Task<bool> UpdateUserAsync(int userId, UserDto updatedUser)
    //{
    //    var user = await _dataContext.Users.FindAsync(userId);
    //    if (user == null)
    //    {
    //        return false;
    //    }

    //    user.FullName = updatedUser.FullName;
    //    user.Email = updatedUser.Email;
    //    user.PhoneNumber = updatedUser.PhoneNumber;
    //    user.Password = updatedUser.Password;

    //    _dataContext.Users.Update(user);
    //    await _dataContext.SaveChangesAsync();
    //    return true;
    //}

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
