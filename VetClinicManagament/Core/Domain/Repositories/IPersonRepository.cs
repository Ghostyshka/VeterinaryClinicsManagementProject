using Domain.Interfaces;

namespace Domain.Repositories;

public interface IPersonRepository
{
    Task AddPersonAsync<T>(T person) where T : class;
    Task<T?> GetPersonByEmailAsync<T>(string email) where T : class, IPerson;
    //Task GetPersonByEmailAsync(object email); // Optional, for non-generic access
}