using Domain.Entities;

namespace Domain.Repositories;

public interface IServiceTypeRepository
{
    Task<IEnumerable<ServiceType>> GetAllAsync();
    Task<ServiceType> GetByIdAsync(int id);
    Task AddAsync(ServiceType serviceType);
    Task UpdateAsync(ServiceType serviceType);
    Task DeleteAsync(int id);
}