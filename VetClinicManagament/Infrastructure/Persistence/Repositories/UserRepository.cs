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

    //public async Task<int> AddUserAsync(UserRegistrationDto newUser)
    //{
    //    var user = new User
    //    {
    //        FullName = newUser.FullName,
    //        LastName = newUser.LastName,
    //        Password = newUser.Password,
    //        Email = newUser.Email,
    //        UserRole = newUser.UserRole
    //    };

    //    _dataContext.Users.Add(user);
    //    await _dataContext.SaveChangesAsync();
    //    return user.UserId;
    //}

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
            return null;
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

    public async Task<bool> UpdateUserAsync(int userId, UserDto updatedUser)
    {
        var user = await _dataContext.Users.FindAsync(userId);
        if (user == null)
        {
            return false;
        }

        user.FullName = updatedUser.FirstName;
        user.Password = updatedUser.Password;
        user.Email = updatedUser.Email;

        _dataContext.Users.Update(user);
        await _dataContext.SaveChangesAsync();
        return true;
    }
}
