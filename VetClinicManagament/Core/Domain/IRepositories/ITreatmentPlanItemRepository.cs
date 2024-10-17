using Domain.Entities;

namespace Domain.Repositories;

public interface ITreatmentPlanItemRepository
{
    Task<IEnumerable<TreatmentPlanItem>> GetItemsByPlanIdAsync(int planId);
    Task AddAsync(TreatmentPlanItem item);
    Task DeleteAsync(int id);
}