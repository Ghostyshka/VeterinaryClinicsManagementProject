namespace Domain.Models.Dtos;

public class MedicalDto
{
    public int MedicalId { get; set; }
    public string MedicalName { get; set; }
    public int MedicalTypeId { get; set; }
    public decimal MedicalPrice { get; set; }
    public int MedicalQuantity { get; set; }
    public DateTime ExpirationDate { get; set; }
}