using VetClinic.Domain.Models;
using VetClinic.Domain.Models.Dtos;

namespace VetClinic.Core.IRepository;

public interface IUserRepository
{
    Task<int> AddUserAsync(UserDto newUser);
    Task<UserModel> GetUserByUsernameAsync(string userName);
}