using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinic.Core.IRepository;
using VetClinic.Domain.Data;
using VetClinic.Domain.Entity;
using VetClinic.Domain.Models;
using VetClinic.Domain.Models.Dtos;


namespace VetClinic.Core.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> AddUserAsync(UserDto newUser)
    {
        var user = new User
        {
            FirstName = newUser.LastName,
            LastName = newUser.LastName,
            Username = newUser.Username,
            DateOfBirth = newUser.DateOfBirth,
            UserRole = newUser.UserRole,
            Email = newUser.Email,
            PhoneNumber = newUser.PhoneNumber,
            Password = newUser.Password,
            CreatedAt = newUser.CreatedAt
        };

        _dataContext.Users.Add(user);
        await _dataContext.SaveChangesAsync();

        return user.UserId;
    }

    //public async Task<UserModel> GetUserByUsernameAsync(string userName)        //ask about type of search
    //{
    //    var user = await _dataContext.Users
    //        .Where(u => u.Username == userName)
    //        .Select(u => new UserModel
    //        {
    //            PasswordHash = u.Password,
    //            Username = u.Username,
    //            UserId = u.UserId
    //        })
    //        .FirstOrDefaultAsync();

    //    return user;
    //}

    public async Task<UserModel> GetUserByIdAsync(int userId)
    {
        var user = await _dataContext.Users
            .Where(u => u.UserId == userId)
            .Select(u => new UserModel
            {
                UserRole = u.UserRole,
                UserId = u.UserId
            })
            .FirstOrDefaultAsync();

        return user;
    }
    
    public async Task<IActionResult> DeleteUserAsync(int userId)
    {
        var user = await _dataContext.Users.FindAsync(userId);
        if (user == null)
        {
            return new NotFoundResult();
        }

        _dataContext.Users.Remove(user);
        await _dataContext.SaveChangesAsync();

        return new NoContentResult();
    }

    public async Task<IActionResult> UpdateUserAsync(int userId, UserDto updatedUser)
    {
        var user = await _dataContext.Users.FindAsync(userId);
        if (user == null)
        {
            return new NotFoundResult();
        }

        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.Username = updatedUser.Username;
        user.DateOfBirth = updatedUser.DateOfBirth;
        user.UserRole = updatedUser.UserRole;
        user.Email = updatedUser.Email;
        user.PhoneNumber = updatedUser.PhoneNumber;
        user.Password = updatedUser.Password;
        user.CreatedAt = updatedUser.CreatedAt;

        _dataContext.Users.Update(user);
        await _dataContext.SaveChangesAsync();

        return new OkObjectResult(new UserModel
        {
            UserId = user.UserId,
            Username = user.Username,
            PasswordHash = user.Password
        });
    }

    public void Dispose()
    {
        _dataContext?.Dispose();
    }
}