using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class TreatmentPlanRepository : ITreatmentPlanRepository
{
    private readonly DataContext _dataContext;

    public TreatmentPlanRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TreatmentPlan> GetByIdAsync(int id)
    {
        return await _dataContext.TreatmentPlan
            .Include(tp => tp.TreatmentPlanItems)
            .FirstOrDefaultAsync(tp => tp.PlanId == id);
    }

    public async Task<IEnumerable<TreatmentPlan>> GetAllAsync()
    {
        return await _dataContext.TreatmentPlan
            .Include(tp => tp.TreatmentPlanItems)
            .ToListAsync();
    }

    public async Task AddAsync(TreatmentPlan treatmentPlan)
    {
        await _dataContext.TreatmentPlan.AddAsync(treatmentPlan);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TreatmentPlan treatmentPlan)
    {
        _dataContext.TreatmentPlan.Update(treatmentPlan);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var treatmentPlan = await GetByIdAsync(id);
        _dataContext.TreatmentPlan.Remove(treatmentPlan);
        await _dataContext.SaveChangesAsync();
    }
}