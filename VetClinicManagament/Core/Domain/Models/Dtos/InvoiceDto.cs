using Domain.Enum;

namespace Domain.Models.Dtos;

public class InvoiceDto
{
    public int VisitId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; }
    public List<int> InvoiceItems { get; set; }
}