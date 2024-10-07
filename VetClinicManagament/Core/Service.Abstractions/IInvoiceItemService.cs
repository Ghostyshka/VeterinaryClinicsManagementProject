using Domain.Models.Dtos;

namespace Contracts;

public interface IInvoiceItemService
{
    Task<IEnumerable<InvoiceItemDto>> GetAllAsync();
    Task<InvoiceItemDto> GetByIdAsync(int id);
    Task<InvoiceItemDto> AddAsync(InvoiceItemDto invoiceItemDto);
    Task<InvoiceItemUpdateDto> UpdateAsync(InvoiceItemUpdateDto invoiceItemDto);
    Task<bool> DeleteAsync(int id);
}