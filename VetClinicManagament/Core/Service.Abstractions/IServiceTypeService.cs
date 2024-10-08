using Domain.Entities;

namespace Contracts;

public interface IServiceTypeService
{
    Task<IEnumerable<ServiceType>> GetAllAsync();
    Task<ServiceType> GetByIdAsync(int id);
    Task CreateAsync(ServiceType serviceType);
    Task UpdateAsync(ServiceType serviceType);
    Task DeleteAsync(int id);
}