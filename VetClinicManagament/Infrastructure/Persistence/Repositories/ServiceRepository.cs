using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly DataContext _dataContext;

    public ServiceRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _dataContext.Service.ToListAsync();
    }

    public async Task<Service> GetByIdAsync(int id)
    {
        return await _dataContext.Service.FindAsync(id);
    }

    public async Task AddAsync(Service service)
    {
        await _dataContext.Service.AddAsync(service);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Service service)
    {
        _dataContext.Service.Update(service);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var service = await _dataContext.Service.FindAsync(id);
        if (service != null)
        {
            _dataContext.Service.Remove(service);
            await _dataContext.SaveChangesAsync();
        }
    }
}