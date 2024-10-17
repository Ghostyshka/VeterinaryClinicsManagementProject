using Domain.Entities;

namespace Domain.Repositories;

public interface IVisitRepository
{
    Task<IEnumerable<Visit>> GetAllAsync();
    Task<Visit> GetByIdAsync(int id);
    Task AddAsync(Visit visit);
    Task UpdateAsync(Visit visit);
    Task<bool> DeleteAsync(int id);
}