using Domain.Models.Dtos;

namespace Contracts
{
    public interface IVisitReportService
    {
        Task<VisitReportDto> GetVisitReportByIdAsync(int visitId);
    }
}