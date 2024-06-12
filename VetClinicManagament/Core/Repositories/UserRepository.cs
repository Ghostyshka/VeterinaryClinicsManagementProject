using System.Data;
using VetClinic.Core.Repositories.Base;
namespace VetClinic.Core.Repositories;


public class UsersRepository : BaseRepository
{
    public UsersRepository(IDbTransaction transaction)
      : base(transaction)
    {


    }
}
