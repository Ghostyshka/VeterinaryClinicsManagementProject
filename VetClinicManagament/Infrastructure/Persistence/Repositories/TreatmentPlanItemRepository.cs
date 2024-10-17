using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class TreatmentPlanItemRepository : ITreatmentPlanItemRepository
{
    private readonly DataContext _dataContext;

    public TreatmentPlanItemRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<TreatmentPlanItem>> GetItemsByPlanIdAsync(int planId)
    {
        return await _dataContext.TreatmentPlanItem
            .Where(item => item.PlanId == planId)
            .ToListAsync();
    }

    public async Task AddAsync(TreatmentPlanItem item)
    {
        await _dataContext.TreatmentPlanItem.AddAsync(item);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        int affectedRows = await _dataContext.TreatmentPlanItem
            .Where(x => x.PlanItemId == id)
            .ExecuteDeleteAsync();

        if (affectedRows == 0) return;
    }
}