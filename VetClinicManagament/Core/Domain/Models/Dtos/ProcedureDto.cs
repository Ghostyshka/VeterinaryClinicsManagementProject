namespace Domain.Models.Dtos;

public class ProcedureDto
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public decimal ServicePrice { get; set; }
    public int? MedicalId { get; set; }
    public int ServiceTypeId { get; set; }
}