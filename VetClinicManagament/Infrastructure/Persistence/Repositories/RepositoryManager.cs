﻿using Domain.Repositories;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    public IClientRepository ClientRepository { get; init; }

    public IUserRepository UserRepository {  get; init; }

    public IEmployeeRepository EmployeeRepository { get; init; }

    public IPersonRepository PersonRepository { get; init; }

    public IInvoiceRepository InvoiceRepository { get; init; }

    public RepositoryManager(IClientRepository clientRepository, IUserRepository userRepository, 
        IEmployeeRepository employeeRepository, IPersonRepository personRepository, IInvoiceRepository invoiceRepository)
    {
        ClientRepository = clientRepository;
        UserRepository = userRepository;
        EmployeeRepository = employeeRepository;
        PersonRepository = personRepository;
        InvoiceRepository = invoiceRepository;
    }
}