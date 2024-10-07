using Domain.Entities;
using Domain.Enum;

namespace Domain.Models.Dtos;

public class AddInvoiceDto
{
    public int InvoiceId { get; set; }

    public int VisitId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; }

    public InvoiceItem InvoiceItem { get; set; }
}