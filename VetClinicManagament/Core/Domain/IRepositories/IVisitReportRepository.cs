using Domain.Entities;

namespace Domain.IRepositories;

public interface IVisitReportRepository
{
    Task<Visit> GetVisitByIdAsync(int visitId);
}