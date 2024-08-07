using Contracts;
using Microsoft.Extensions.Configuration;

namespace Service;

public class UserService : IUserService
{
    private IConfiguration _configuration;

    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }


}