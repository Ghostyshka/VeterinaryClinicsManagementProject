namespace Domain.Models.Dtos;

public class ProcedureDto
{
    public string ServiceName { get; set; }
    public decimal ServicePrice { get; set; }

    public ServiceTypeForProcedureDto ServiceType { get; set; }
}