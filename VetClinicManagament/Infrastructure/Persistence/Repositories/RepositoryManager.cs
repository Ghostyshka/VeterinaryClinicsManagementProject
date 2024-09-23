using Domain.Repositories;
using Persistence.Data;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    public IClientRepository ClientRepository { get; init; }

    public IUserRepository UserRepository {  get; init; }

    public IEmployeeRepository EmployeeRepository { get; init; }

    public IPersonRepository PersonRepository { get; init; }

    public RepositoryManager(IClientRepository clientRepository, IUserRepository userRepository, 
        IEmployeeRepository employeeRepository, IPersonRepository personRepository)
    {
        ClientRepository = clientRepository;
        UserRepository = userRepository;
        EmployeeRepository = employeeRepository;
        PersonRepository = personRepository;
    }
}