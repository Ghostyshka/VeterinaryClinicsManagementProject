using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class ServiceTypeRepository : IServiceTypeRepository
{
    private readonly DataContext _dataContext;

    public ServiceTypeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<ServiceType>> GetAllAsync()
    {
        return await _dataContext.ServiceType.ToListAsync();
    }

    public async Task<ServiceType> GetByIdAsync(int id)
    {
        return await _dataContext.ServiceType.FindAsync(id);
    }

    public async Task AddAsync(ServiceType serviceType)
    {
        await _dataContext.ServiceType.AddAsync(serviceType);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ServiceType serviceType)
    {
        _dataContext.ServiceType.Update(serviceType);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var serviceType = await _dataContext.ServiceType.FindAsync(id);
        if (serviceType != null)
        {
            _dataContext.ServiceType.Remove(serviceType);
            await _dataContext.SaveChangesAsync();
        }
    }
}