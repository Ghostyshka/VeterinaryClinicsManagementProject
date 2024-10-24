namespace Domain.Entities;

public class TreatmentPlan
{
    public int PlanId { get; set; }
    public int VisitId { get; set; }
    public Visit Visit { get; set; }
    public DateTime StartOfTreatment { get; set; }
    public DateTime EndOfTreatment { get; set; }
    public bool InClinic { get; set; }

    public ICollection<TreatmentPlanItem> TreatmentPlanItems { get; set; }
}