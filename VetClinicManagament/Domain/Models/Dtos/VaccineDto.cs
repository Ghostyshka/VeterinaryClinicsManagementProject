namespace Domain.Models.Dtos;

public class VaccineDto
{
    public string VaccineName { get; set; }
    public string Manufacturer { get; set; }
    public DateTime ExpiryDate { get; set; }
    public VaccineTypeDto VaccineType { get; set; }
}