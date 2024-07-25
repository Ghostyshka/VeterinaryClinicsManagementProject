using Domain.Enum;

namespace Domain.Models.Dtos;

public class VaccineTypeDto
{
    public VaccineType VaccineType { get; set; }

    public ICollection<VaccineDto> Vaccines { get; set; } = new List<VaccineDto>();
}