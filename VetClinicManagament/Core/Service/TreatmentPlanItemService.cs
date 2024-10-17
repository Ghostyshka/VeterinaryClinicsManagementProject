using Contracts;
using Domain.Entities;
using Domain.Repositories;

namespace Service;

public class TreatmentPlanItemService : ITreatmentPlanItemService
{
    private readonly ITreatmentPlanItemRepository _repository;

    public TreatmentPlanItemService(ITreatmentPlanItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TreatmentPlanItem>> GetItemsByPlanIdAsync(int planId)
    {
        return await _repository.GetItemsByPlanIdAsync(planId);
    }

    public async Task AddAsync(TreatmentPlanItem item)
    {
        await _repository.AddAsync(item);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}