namespace Domain.Models.Dtos;

public class InvoiceItemDto
{
    public int ItemId { get; set; }
    public int InvoiceId { get; set; }
    public string ItemType { get; set; }
}