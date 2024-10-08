namespace Domain.Entities;

public class Medicals
{
    public int MedicalId { get; set; }
    public string MedicalName { get; set; }
    public int MedicalTypeId { get; set; }
    public decimal MedicalPrice { get; set; }
    public int MedicalQuantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    public MedicalType MedicalsType { get; set; }
}