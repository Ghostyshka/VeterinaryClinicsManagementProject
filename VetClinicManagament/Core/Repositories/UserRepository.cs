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
            FirstName = newUser.FirstName,
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


    public async Task<UserModel> GetUserByUsernameAsync(string userName)
    {
        var user = await _dataContext.Users
            .Where(u => u.Username == userName)
            .Select(u => new UserModel
            {
                PasswordHash = u.Password,
                Username = u.Username,
                UserId = u.UserId
            })
            .FirstOrDefaultAsync();

        return user;
    }



    public void Dispose()
    {
        _dataContext?.Dispose();
    }
}