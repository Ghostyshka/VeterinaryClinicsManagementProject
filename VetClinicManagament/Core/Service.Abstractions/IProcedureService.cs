using Domain.Entities;

namespace Contracts;

public interface IProcedureService
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service> GetByIdAsync(int id);
    Task CreateAsync(Service service);
    Task UpdateAsync(Service service);
    Task DeleteAsync(int id);
}