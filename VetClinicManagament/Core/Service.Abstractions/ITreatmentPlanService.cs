using Domain.Models.Dtos;

namespace Contracts;

public interface ITreatmentPlanService
{
    Task<TreatmentPlanDto> GetByIdAsync(int id);
    Task<IEnumerable<TreatmentPlanDto>> GetAllAsync();
    Task<TreatmentPlanDto> AddAsync(TreatmentPlanDto treatmentPlanDto);
    Task<TreatmentPlanDto> UpdateAsync(TreatmentPlanDto treatmentPlanDto);
    Task DeleteAsync(int id);
}