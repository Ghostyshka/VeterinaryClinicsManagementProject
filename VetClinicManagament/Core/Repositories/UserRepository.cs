using Dapper;
using System.Data;
using VetClinic.Core.IRepository;
using VetClinic.Core.Repositories.Base;
using VetClinic.Domain.Models;
using VetClinic.Domain.Models.Dtos;

namespace VetClinic.Core.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IDbTransaction transaction)
        : base(transaction)
    {
    }

    public async Task<int> AddUserAsync(UserDto newUser)
    {
        return await Connection.ExecuteScalarAsync<int>(
            @"INSERT INTO [Users](FirstName, LastName, Username, DateOfBirth, UserRole, Email, PhoneNumber, Password, CreatedAt)
                  VALUES (@FirstName, @LastName, @Username, @DateOfBirth, @UserRole, @Email, @PhoneNumber, @Password, @CreatedAt);
                  SELECT CAST(SCOPE_IDENTITY() as int);",
            param: new
            {
                newUser.FirstName,
                newUser.LastName,
                newUser.Username,
                newUser.DateOfBirth,
                newUser.UserRole,
                newUser.Email,
                newUser.PhoneNumber,
                newUser.Password,
                newUser.CreatedAt
            },
            transaction: Transaction
        );
    }

    public async Task<UserModel> GetUserByUsernameAsync(string userName)
    {
        var user = await Connection.QueryFirstOrDefaultAsync<UserModel>(
            @"SELECT Password AS PasswordHash, UserName, UserId  FROM [Users] WHERE UserName = @Username",
            param: new { Username = userName },
            transaction: Transaction
        );

        return user;
    }

}