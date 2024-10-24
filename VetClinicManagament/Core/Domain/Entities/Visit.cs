using Domain.Enum;

namespace Domain.Entities;

public class Visit
{
    public int VisitId { get; set; }
    public DateTime DataOfVisit { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public VisitStatus Status { get; set; }
    public string Description { get; set; }

    public ICollection<TreatmentPlan> TreatmentPlan { get; set; }
    public ICollection<Invoice> Invoice { get; set; }
}