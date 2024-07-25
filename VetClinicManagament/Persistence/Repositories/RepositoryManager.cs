using Domain.Repositories;
using Persistence.Data;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    public IClientRepository ClientRepository { get; init; }

    public IUserRepository UserRepository {  get; init; }

    public RepositoryManager(IClientRepository clientRepository, IUserRepository userRepository)
    {
        ClientRepository = clientRepository;
        UserRepository = userRepository;
    }
}