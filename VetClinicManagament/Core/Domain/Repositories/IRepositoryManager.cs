namespace Domain.Repositories;

public interface IRepositoryManager
{
    IClientRepository ClientRepository { get; }
    IUserRepository UserRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IPersonRepository PersonRepository { get; }
    IInvoiceRepository InvoiceRepository { get; }
}