using Domain.Enum;

namespace Domain.Entities;

public class Invoice
{
    public int InvoiceId { get; set; }

    public int VisitId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; }

    public InvoiceItem InvoiceItem { get; set; }

    public ICollection<Visit> Visit { get; set; }
}