using Domain.Entities;
using Domain.Models.Dtos;

namespace Domain.Repositories;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
    Task<Invoice> GetInvoiceByIdAsync(int id);
    Task<Invoice> AddInvoiceAsync(Invoice invoice);
    Task UpdateInvoiceAsync(Invoice invoice);
    Task DeleteInvoiceAsync(int id);
    Task<InvoiceVisitDetailsDto> GetInvoiceDetailsAsync(int invoiceId);
}