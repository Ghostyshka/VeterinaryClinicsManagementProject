using Domain.Entities;

namespace Contracts;

public interface ITreatmentPlanItemService
{
    Task<IEnumerable<TreatmentPlanItem>> GetItemsByPlanIdAsync(int planId);
    Task AddAsync(TreatmentPlanItem item);
    Task DeleteAsync(int id);
}