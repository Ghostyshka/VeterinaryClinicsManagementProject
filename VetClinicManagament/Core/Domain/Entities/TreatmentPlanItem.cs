namespace Domain.Entities;

public class TreatmentPlanItem
{
    public int PlanItemId { get; set; }
    public int PlanId { get; set; }
    public int ServiceId { get; set; }
    public int MedicalId { get; set; }
    public string ItemDescription { get; set; }
    public double Dosage { get; set; }
    public int Quantity { get; set; }

    public TreatmentPlan TreatmentPlan { get; set; }
    public Service Service { get; set; }
    public Medical Medical { get; set; }
}