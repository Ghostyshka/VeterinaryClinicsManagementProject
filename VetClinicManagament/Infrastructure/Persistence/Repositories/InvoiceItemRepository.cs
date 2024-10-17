using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class InvoiceItemRepository : IInvoiceItemRepository
{
    private readonly DataContext _dataContext;

    public InvoiceItemRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<InvoiceItem>> GetAllAsync()
    {
        var invoiceItems = await _dataContext.InvoiceItem.ToListAsync();
        return [.. invoiceItems];
    }

    public async Task<InvoiceItem?> GetByIdAsync(int id)
    {
        return await _dataContext.InvoiceItem.FirstOrDefaultAsync(x => x.InvoiceId == id);
    }

    public async Task<int> AddAsync(InvoiceItem invoiceItem)
    {
        await _dataContext.InvoiceItem.AddAsync(invoiceItem);
        await _dataContext.SaveChangesAsync();
        return invoiceItem.ItemId;
    }

    public async Task UpdateAsync(InvoiceItem invoiceItemDto)
    {
        var invoiceItem = await _dataContext.InvoiceItem.FindAsync(invoiceItemDto.ItemId);
        if (invoiceItem == null) return;

        _dataContext.InvoiceItem.Update(invoiceItem);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var invoiceItem = await _dataContext.InvoiceItem.FindAsync(id);
        if (invoiceItem != null)
        {
            _dataContext.InvoiceItem.Remove(invoiceItem);
            await _dataContext.SaveChangesAsync();
        }
    }
}