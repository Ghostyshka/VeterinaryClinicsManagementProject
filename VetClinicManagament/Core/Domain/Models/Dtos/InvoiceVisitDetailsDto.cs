using Domain.Enum;

namespace Domain.Models.Dtos;

public class InvoiceVisitDetailsDto
{
    public int InvoiceId { get; set; }
    public int VisitId { get; set; }
    public DateTime VisitDate { get; set; }
    public string UserName { get; set; } 
    public string EmployeeName { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<InvoiceItemDto> InvoiceItems { get; set; }
}