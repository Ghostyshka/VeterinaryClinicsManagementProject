using Domain.Enum;

namespace Domain.Models.Dtos;

public class VisitReportDto
{
    public int VisitId { get; set; }
    public DateTime DataOfVisit { get; set; }

    public int UserId { get; set; }
    public string UserFullName { get; set; }
    public string UserEmail { get; set; }
    public string UserPhoneNumber { get; set; }

    public int EmployeeId { get; set; }
    public string EmployeeFullName { get; set; }
    public string EmployeeEmail { get; set; }
    public string EmployeePhoneNumber { get; set; }

    public List<InvoiceDto> Invoices { get; set; }

    public List<TreatmentPlanDto> TreatmentPlans { get; set; }

    public VisitStatus Status { get; set; }
    public string Description { get; set; }
}