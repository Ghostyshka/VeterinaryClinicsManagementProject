using Domain.Entities;

namespace Domain.Models.Dtos;

public class ProcedureUpdateDto
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public decimal ServicePrice { get; set; }

    public Service Service { get; set; }
    public ServiceType ServiceType { get; set; }
}