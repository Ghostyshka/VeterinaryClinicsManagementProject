using Domain.Enum;

namespace Domain.Entities;

public class InvoiceItem
{
    public int ItemId { get; set; }
    public int InvoiceId { get; set; }
    public int VisitId { get; set; }
    public string ItemType { get; set; }

    public ICollection<Invoice> Invoice { get; set; }
}