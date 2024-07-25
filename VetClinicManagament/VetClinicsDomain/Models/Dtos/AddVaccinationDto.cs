namespace VetClinic.Domain.Models.Dtos;

public class AddVaccinationDto
{
    public VaccineDto Vaccine { get; set; }
    public VaccineTypeDto VaccineType { get; set; }

    public int UserId { get; set; }
    public int AnimalId { get; set; }
}