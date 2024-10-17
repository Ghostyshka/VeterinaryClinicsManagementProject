using Domain.Models.Dtos;

namespace Contracts;

public interface IInvoiceService
{
    Task<InvoiceDto> AddInvoiceAsync(InvoiceDto newInvoice);
    Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync();
    Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId);
    Task UpdateInvoiceAsync(InvoiceDto updatedInvoice);
    Task DeleteInvoiceAsync(int invoiceId);
}