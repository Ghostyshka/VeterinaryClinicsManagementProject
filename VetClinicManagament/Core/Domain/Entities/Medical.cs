namespace Domain.Entities;

public class Medical
{
    public int MedicalId { get; set; }
    public string MedicalName { get; set; }
    public int MedicalTypeId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    public MedicalsTypes MedicalsType { get; set; }

    public ICollection<TreatmentPlanItem> TreatmentPlanItems { get; set; }
}