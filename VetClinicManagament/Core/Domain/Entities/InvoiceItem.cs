namespace Domain.Entities;

public class InvoiceItem
{
    public int ItemId { get; set; }
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public string ItemType { get; set; }
}