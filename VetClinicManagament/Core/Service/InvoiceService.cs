using Domain.Entities;
using Domain.Repositories;
using Contracts;
using Domain.Models.Dtos;

namespace Service;

public class InvoiceService : IInvoiceService
{
    private readonly IRepositoryManager _repositoryManager;


    public InvoiceService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
    {
        return await _repositoryManager.InvoiceRepository.GetAllInvoicesAsync();
    }

    public async Task<InvoiceDto> GetInvoiceByIdAsync(int id)
    {
        return await _repositoryManager.InvoiceRepository.GetInvoiceByIdAsync(id);
    }

    public async Task<InvoiceDto> AddInvoiceAsync(InvoiceDto invoice)
    {
        invoice.CreatedAt = DateTime.UtcNow;
        invoice.UpdateAt = DateTime.UtcNow;
        return await _repositoryManager.InvoiceRepository.AddInvoiceAsync(invoice);
    }

    public async Task UpdateInvoiceAsync(InvoiceDto invoice)
    {
        invoice.UpdateAt = DateTime.UtcNow;
        await _repositoryManager.InvoiceRepository.UpdateInvoiceAsync(invoice);
    }

    public async Task DeleteInvoiceAsync(int id)
    {
        await _repositoryManager.InvoiceRepository.DeleteInvoiceAsync(id);
    }
}