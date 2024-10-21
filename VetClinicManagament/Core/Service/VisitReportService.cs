using Contracts;
using Domain.Enum;
using Domain.Models.Dtos;
using Domain.Repositories;

namespace Service;

public class VisitReportService : IVisitReportService
{
    private readonly IVisitRepository _visitRepository;

    public VisitReportService(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    public async Task<VisitReportDto> GetVisitReportByIdAsync(int visitId)
    {
        var visit = await _visitRepository.GetByIdAsync(visitId);
        //if (visit == null) throw new NotFoundException($"Visit with ID {visitId} not found.");

        var dto = new VisitReportDto
        {
            VisitId = visit.VisitId,
            DataOfVisit = visit.DataOfVisit,
            UserId = visit.UserId,
            UserFullName = visit.User.FullName,
            UserEmail = visit.User.Email,
            UserPhoneNumber = visit.User.PhoneNumber,
            EmployeeId = visit.EmployeeId,
            EmployeeFullName = visit.Employee.EmployeeFullName,
            EmployeeEmail = visit.Employee.Email,
            InvoiceId = visit.Invoice?.InvoiceId,
            InvoiceCreatedAt = visit.Invoice?.CreatedAt ?? DateTime.MinValue,
            InvoiceStatus = (InvoiceStatus)(visit.Invoice?.InvoiceStatus),
            InvoiceItems = visit.Invoice?.InvoiceItems.Select(ii => new InvoiceItemDto
            {
            }).ToList() ?? new List<InvoiceItemDto>(),
            StartOfTreatment = visit.TreatmentPlan?.StartOfTreatment ?? DateTime.MinValue,
            EndOfTreatment = visit.TreatmentPlan?.EndOfTreatment ?? DateTime.MinValue,
            InClinic = visit.TreatmentPlan?.InClinic ?? false,
            TreatmentPlanItems = visit.TreatmentPlan?.TreatmentPlanItems.Select(tpi => new TreatmentPlanItemDto
            {
            }).ToList() ?? new List<TreatmentPlanItemDto>(),
            Status = visit.Status,
            Description = visit.Description
        };

        return dto;
    }

}