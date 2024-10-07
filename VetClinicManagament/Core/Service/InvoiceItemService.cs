using Domain.Entities;
using Contracts;
using AutoMapper;
using Domain.Repositories;
using Domain.Models.Dtos;

namespace Service;

public class InvoiceItemService : IInvoiceItemService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public InvoiceItemService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InvoiceItemDto>> GetAllAsync()
    {
        var invoiceItems = await _repositoryManager.InvoiceItemRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<InvoiceItemDto>>(invoiceItems);
    }

    public async Task<InvoiceItemDto> GetByIdAsync(int id)
    {
        var invoiceItem = await _repositoryManager.InvoiceItemRepository.GetByIdAsync(id);
        return _mapper.Map<InvoiceItemDto>(invoiceItem);
    }

    public async Task<InvoiceItemDto> AddAsync(InvoiceItemDto invoiceItemDto)
    {
        var invoiceItem = _mapper.Map<InvoiceItem>(invoiceItemDto);
        await _repositoryManager.InvoiceItemRepository.AddAsync(invoiceItem);
        return invoiceItemDto;
    }

    public async Task<InvoiceItemDto> UpdateAsync(InvoiceItemDto invoiceItemDto)
    {
        var invoiceItem = _mapper.Map<InvoiceItem>(invoiceItemDto);
        await _repositoryManager.InvoiceItemRepository.UpdateAsync(invoiceItem);
        return invoiceItemDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _repositoryManager.InvoiceItemRepository.GetByIdAsync(id);
        if (item == null) return false;

        await _repositoryManager.InvoiceItemRepository.DeleteAsync(id);
        return true;
    }
}