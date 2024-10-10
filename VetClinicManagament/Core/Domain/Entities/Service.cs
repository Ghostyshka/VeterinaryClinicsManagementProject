namespace Domain.Entities;

public class Service
{
    public int ServiceId { get; set; }
    public int ServiceTypeId { get; set; }
    public int MedicalId { get; set; }
    public decimal Price { get; set; }

    public ServiceType ServiceType { get; set; }
    public Medical Medicals { get; set; }

    public ICollection<TreatmentPlanItem> TreatmentPlanItems { get; set; }
}