using Domain.Entities;
using Domain.Repositories;
using Contracts;
using Domain.Models.Dtos;
using AutoMapper;

namespace Service;

public class InvoiceService : IInvoiceService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public InvoiceService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
    {
        var invoices = await _repositoryManager.InvoiceRepository.GetAllInvoicesAsync();
        return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
    }

    public async Task<InvoiceDto> GetInvoiceByIdAsync(int id)
    {
        var invoice = await _repositoryManager.InvoiceRepository.GetInvoiceByIdAsync(id);
        return _mapper.Map<InvoiceDto>(invoice);
    }

    public async Task<InvoiceDto> AddInvoiceAsync(InvoiceDto invoice)
    {
        // Set timestamps
        invoice.CreatedAt = DateTime.UtcNow;
        invoice.UpdateAt = DateTime.UtcNow;

        var invoiceEntity = _mapper.Map<Invoice>(invoice);
        var createdInvoice = await _repositoryManager.InvoiceRepository.AddInvoiceAsync(invoiceEntity);
        return _mapper.Map<InvoiceDto>(createdInvoice);
    }

    public async Task UpdateInvoiceAsync(InvoiceDto invoice)
    {
        invoice.UpdateAt = DateTime.UtcNow;

        var invoiceEntity = _mapper.Map<Invoice>(invoice);
        await _repositoryManager.InvoiceRepository.UpdateInvoiceAsync(invoiceEntity);
    }

    public async Task DeleteInvoiceAsync(int id)
    {
        await _repositoryManager.InvoiceRepository.DeleteInvoiceAsync(id);
    }
}