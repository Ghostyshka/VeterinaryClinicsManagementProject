namespace Domain.Models.Dtos;

public class TreatmentPlanItemDto
{
    public int PlanItemId { get; set; }
    public int PlanId { get; set; }
    public int ServiceId { get; set; }
    public int MedicalId { get; set; }
    public string ItemDescription { get; set; }
    public int Dosage { get; set; }
    public int Quantity { get; set; }
}