using Domain.Entities;
using Domain.Models.Dtos;

namespace Domain.Repositories;

public interface IInvoiceItemRepository
{
    Task<IEnumerable<InvoiceItem>> GetAllAsync();
    Task<InvoiceItem> GetByIdAsync(int id);
    Task<int> AddAsync(InvoiceItem invoiceItemDto);
    Task UpdateAsync(InvoiceItem invoiceItemDto);
    Task DeleteAsync(int id);
}