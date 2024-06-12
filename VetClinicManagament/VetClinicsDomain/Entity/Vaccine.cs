namespace VetClinic.Domain.Entity;

internal class Vaccine
{
    public int VaccineId { get; set; }
    public string Name { get; set; }
    public VaccineType Type { get; set; }
    public string Manufacturer { get; set; }
    public DateTime ExpiryDate { get; set; }
}