using Domain.Models.Dtos;

namespace Contracts;

public interface IInvoiceItemService
{
    Task<IEnumerable<InvoiceItemDto>> GetAllAsync();
    Task<InvoiceItemDto> GetByIdAsync(int id);
    Task<InvoiceItemDto> AddAsync(InvoiceItemDto invoiceItemDto);
    Task<InvoiceItemDto> UpdateAsync(InvoiceItemDto invoiceItemDto);
    Task<bool> DeleteAsync(int id);
}