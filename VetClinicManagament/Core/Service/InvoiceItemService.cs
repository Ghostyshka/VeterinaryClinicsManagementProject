using Domain.Entities;
using Contracts;
using AutoMapper;
using Domain.Repositories;
using Domain.Models.Dtos;

namespace Service;

public class InvoiceItemService : IInvoiceItemService
{
    private readonly IInvoiceItemRepository _invoiceItemRepository;
    private readonly IMapper _mapper;

    public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository, IMapper mapper)
    {
        _invoiceItemRepository = invoiceItemRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InvoiceItemDto>> GetAllAsync()
    {
        var invoiceItems = await _invoiceItemRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<InvoiceItemDto>>(invoiceItems);
    }

    public async Task<InvoiceItemDto> GetByIdAsync(int id)
    {
        var invoiceItem = await _invoiceItemRepository.GetByIdAsync(id);
        return _mapper.Map<InvoiceItemDto>(invoiceItem);
    }

    public async Task<InvoiceItemDto> AddAsync(InvoiceItemDto invoiceItemDto)
    {
        var invoiceItem = _mapper.Map<InvoiceItem>(invoiceItemDto);
        await _invoiceItemRepository.AddAsync(invoiceItem);
        return invoiceItemDto;
    }

    public async Task<InvoiceItemDto> UpdateAsync(InvoiceItemDto invoiceItemDto)
    {
        var invoiceItem = _mapper.Map<InvoiceItem>(invoiceItemDto);
        await _invoiceItemRepository.UpdateAsync(invoiceItem);
        return invoiceItemDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _invoiceItemRepository.GetByIdAsync(id);
        if (item == null) return false;

        await _invoiceItemRepository.DeleteAsync(id);
        return true;
    }
}