using System.Data;

namespace VetClinic.Core.Repositories.Base;

public abstract class BaseRepository
{
    protected IDbTransaction Transaction { get; private set; }
    protected IDbConnection Connection { get { return Transaction.Connection; } }

    public BaseRepository(IDbTransaction transaction)
    {
        Transaction = transaction;
    }
}