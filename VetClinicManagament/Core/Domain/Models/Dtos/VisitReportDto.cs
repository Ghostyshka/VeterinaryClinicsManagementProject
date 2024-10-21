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

    public int? InvoiceId { get; set; }
    public DateTime InvoiceCreatedAt { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; }
    public List<InvoiceItemDto> InvoiceItems { get; set; }

    public int? TreatmentId { get; set; }
    public string TreatmentDescription { get; set; }
    public DateTime StartOfTreatment { get; set; }
    public DateTime EndOfTreatment { get; set; }
    public bool InClinic { get; set; }

    public List<TreatmentPlanItemDto> TreatmentPlanItems { get; set; }
    public VisitStatus Status { get; set; }
    public string Description { get; set; }
}