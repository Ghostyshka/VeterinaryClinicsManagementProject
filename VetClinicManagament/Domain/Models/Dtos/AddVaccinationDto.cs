namespace Domain.Models.Dtos;

public class AddVaccinationDto
{
    public VaccineDto Vaccine { get; set; }

    public int UserId { get; set; }
    public int AnimalId { get; set; }
}