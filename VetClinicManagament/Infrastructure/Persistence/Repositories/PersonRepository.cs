using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly DataContext _dataContext;

    public PersonRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task AddPersonAsync<T>(T person) where T : class
    {
        if (person is User || person is Employee)
        {
            _dataContext.Set<T>().Add(person);
            await _dataContext.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("Unsupported entity type.");
        }
    }

    //public async Task<T?> GetPersonByEmailAsync<T>(string email) where T : class
    //{
    //    if (typeof(T) == typeof(User))
    //    {
    //        return await _dataContext.Set<User>()
    //            .FirstOrDefaultAsync(u => u.Email == email) as T;
    //    }
    //    else if (typeof(T) == typeof(Employee))
    //    {
    //        return await _dataContext.Set<Employee>()
    //            .FirstOrDefaultAsync(e => e.Email == email) as T;
    //    }
    //    return null;
    //}

    public async Task<T?> GetPersonByEmailAsync<T>(string email) where T : class, IPerson
    {
        return await _dataContext.Set<T>()
            .FirstOrDefaultAsync(p => p.Email == email) as T;
    }
}