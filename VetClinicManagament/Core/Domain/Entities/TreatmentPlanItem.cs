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



    //public int AnimalId { get; set; }
    //public Animal Animal { get; set; }

    //public ICollection<Medicals> Medicals { get; set; } = new List<Medicals>();
    //public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}