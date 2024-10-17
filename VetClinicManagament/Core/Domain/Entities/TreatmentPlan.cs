namespace Domain.Entities;

public class TreatmentPlan
{
    public int PlanId { get; set; }
    public int TreatmentId { get; set; }
    public int ServiceTypeId { get; set; }
    public DateTime StartOfTreatment { get; set; }
    public DateTime EndOfTreatment { get; set; }
    public bool InClinic { get; set; }

    public ServiceType ServiceType { get; set; }

    public ICollection<Visit> Visit { get; set; }
    public ICollection<TreatmentPlanItem> TreatmentPlanItems { get; set; }
}