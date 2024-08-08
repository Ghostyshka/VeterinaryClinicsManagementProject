namespace Domain.Repositories;

public interface IRepositoryManager
{
    IClientRepository ClientRepository { get; }
    IUserRepository UserRepository { get; }
}