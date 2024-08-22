namespace Domain.Entities;

public class TreatmentPlan
{
    public int TreatmentPlanId { get; set; }
    public string PlanName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsAdministeredAtClinic { get; set; } // true for clinic, false for home

    public int AnimalId { get; set; }
    public Animal Animal { get; set; }

    public ICollection<Medicals> Medicals { get; set; } = new List<Medicals>();
    public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}