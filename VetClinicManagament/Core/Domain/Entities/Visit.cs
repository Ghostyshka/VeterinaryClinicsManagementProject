namespace Domain.Entities;

public class Visit
{
    public int VisitId { get; set; }
    public DateTime DataOfVisit { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    // Nullable InvoiceId, because not every visit will have an invoice immediately
    public int? InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    // Every visit should be assigned to an employee (doctor, vet, etc)
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    // Nullable TreatmentPlan for visits that might not require treatments
    public int? TreatmentId { get; set; }
    public TreatmentPlan TreatmentPlan { get; set; }
}