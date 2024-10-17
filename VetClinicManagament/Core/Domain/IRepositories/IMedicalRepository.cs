using Domain.Entities;

namespace Domain.IRepositories;

public interface IMedicalRepository
{
    Task<IEnumerable<Medical>> GetAllAsync();
    Task<Medical> GetByIdAsync(int id);
    Task AddAsync(Medical medical);
    Task UpdateAsync(Medical medical);
    Task DeleteAsync(int id);
}