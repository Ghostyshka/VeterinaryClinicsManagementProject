namespace Domain.Entities;

public class Service
{
    public int ServiceId { get; set; }
    public string ServiceTypeId { get; set; }
    public int MedicalId { get; set; }
    public decimal Price { get; set; }
}