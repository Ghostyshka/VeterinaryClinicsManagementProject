namespace Domain.Models.Dtos;

public class TreatmentPlanItemDto
{
    public int PlanItemId { get; set; }
    public int ServiceId { get; set; }
    public ProcedureDto Service { get; set; }
    public int MedicalId { get; set; }
    public MedicalDto Medical { get; set; }
    public string ItemDescription { get; set; }
    public string Dosage { get; set; }
    public int Quantity { get; set; }
}