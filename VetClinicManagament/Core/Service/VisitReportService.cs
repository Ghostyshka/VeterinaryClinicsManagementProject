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
            EmployeePhoneNumber = visit.Employee.PhoneNumber,

            Invoices = visit.Invoice?.Select(inv => new InvoiceDto
            {
                InvoiceId = inv.InvoiceId,
                CreatedAt = inv.CreatedAt,
                InvoiceStatus = inv.InvoiceStatus,
                InvoiceItems = inv.InvoiceItems?.Select(ii => new InvoiceItemDto
                {
                    InvoiceId = ii.InvoiceId,
                    ItemType = ii.ItemType,
                    Quantity = ii.Quantity,
                    Price = ii.Price,
                }).ToList() ?? new List<InvoiceItemDto>()
            }).ToList() ?? new List<InvoiceDto>(),

            TreatmentPlans = visit.TreatmentPlan?.Select(tp => new TreatmentPlanDto
            {
                PlanId = tp.PlanId,
                StartOfTreatment = tp.StartOfTreatment,
                EndOfTreatment = tp.EndOfTreatment,
                InClinic = tp.InClinic,
                TreatmentPlanItems = tp.TreatmentPlanItems?.Select(tpi => new TreatmentPlanItemDto
                {
                    PlanId = tpi.PlanId,
                    ServiceId = tpi.ServiceId,
                    MedicalId = tpi.MedicalId,
                    ItemDescription = tpi.ItemDescription,
                    Dosage = tpi.Dosage,
                    Quantity = tpi.Quantity,
                }).ToList() ?? new List<TreatmentPlanItemDto>()
            }).ToList() ?? new List<TreatmentPlanDto>(),

            Status = visit.Status,
            Description = visit.Description
        };

        return dto;
    }
}