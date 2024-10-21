using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class VisitReportRepository : IVisitReportRepository
{
    private readonly DataContext _dataContext;

    public VisitReportRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Visit> GetVisitByIdAsync(int visitId)
    {
        return await _dataContext.Visit
            .Include(v => v.User)
            .Include(v => v.Employee)
            .Include(v => v.Invoice)
            .Include(v => v.TreatmentPlan)
            .FirstOrDefaultAsync(v => v.VisitId == visitId);
    }
}