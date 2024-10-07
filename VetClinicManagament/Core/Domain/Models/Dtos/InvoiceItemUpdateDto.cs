namespace Domain.Models.Dtos;

public class InvoiceItemUpdateDto
{
    public int ItemId { get; set; }
    public int InvoiceId { get; set; }
    public string ItemType { get; set; }
}