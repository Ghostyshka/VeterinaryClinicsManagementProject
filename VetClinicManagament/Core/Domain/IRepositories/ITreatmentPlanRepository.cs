using Domain.Entities;

namespace Domain.Repositories;

public interface ITreatmentPlanRepository
{
    Task<TreatmentPlan> GetByIdAsync(int id);
    Task<IEnumerable<TreatmentPlan>> GetAllAsync();
    Task AddAsync(TreatmentPlan treatmentPlan);
    Task UpdateAsync(TreatmentPlan treatmentPlan);
    Task DeleteAsync(int id);
}