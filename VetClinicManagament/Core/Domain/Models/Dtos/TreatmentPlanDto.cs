namespace Domain.Models.Dtos;

public class TreatmentPlanDto
{
    public int PlanId { get; set; }
    public int VisitId { get; set; }
    public DateTime StartOfTreatment { get; set; }
    public DateTime EndOfTreatment { get; set; }
    public bool InClinic { get; set; }

    public List<TreatmentPlanItemDto> TreatmentPlanItems { get; set; }
}