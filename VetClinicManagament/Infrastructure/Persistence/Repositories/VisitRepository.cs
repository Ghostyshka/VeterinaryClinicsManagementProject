using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class VisitRepository : IVisitRepository
{
    private readonly DataContext _dataContext;

    public VisitRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Visit>> GetAllAsync()
    {
        return await _dataContext.Visit.ToListAsync();
    }

    public async Task<Visit> GetByIdAsync(int id) => await _dataContext.Visit
            .Include(v => v.User)
            .Include(v => v.Employee)
            .Include(v => v.Invoice)
            .ThenInclude(i => i.InvoiceItems)
            .Include(v => v.TreatmentPlan)
            .FirstOrDefaultAsync(v => v.VisitId == id);

    public async Task AddAsync(Visit visit)
    {
        await _dataContext.Visit.AddAsync(visit);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Visit visit)
    {
        _dataContext.Visit.Update(visit);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var visit = await _dataContext.Visit.FindAsync(id);
        if (visit == null)
            return false;

        _dataContext.Visit.Remove(visit);
        await _dataContext.SaveChangesAsync();
        return true;
    }
}