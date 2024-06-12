using System.Data;
using VetClinic.Core.Repositories.Base;
using VetClinicsDomain.Entity;
namespace VetClinic.Core.Repositories;


public class UsersRepository : BaseRepository
{
    public UsersRepository(IDbTransaction transaction)
      : base(transaction)
    {
    }


    /*public async Task<int> AddUserAsync(User newUser)
    {
        return await Connection.ExecuteScalarAsync<int>(
            @"INSERT INTO [Users](FullName, UserName, Password, Email, PhoneNumber)
                VALUES (@FullName, @UserName, @Password, @Email, @PhoneNumber);",
            param: new { Fullname = newUser.FullName, UserName = newUser.UserName, Password = newUser.Password, Email = newUser.Email, PhoneNumber = newUser.PhoneNumber },
            transaction: Transaction
        );
    }*/
}
