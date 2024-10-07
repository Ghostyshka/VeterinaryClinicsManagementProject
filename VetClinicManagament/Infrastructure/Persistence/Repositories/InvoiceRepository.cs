using Domain.Entities;
using Persistence.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly DataContext _dataContext;

    public InvoiceRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
    {
        return await _dataContext.Invoice.Include(i => i.InvoiceItems).Include(i => i.Visit).ToListAsync();
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        return await _dataContext.Invoice.Include(i => i.InvoiceItems).Include(i => i.Visit).FirstOrDefaultAsync(i => i.InvoiceId == id);
    }

    public async Task<Invoice> AddInvoiceAsync(Invoice invoice)
    {
        await _dataContext.Invoice.AddAsync(invoice);
        await _dataContext.SaveChangesAsync();
        return invoice;
    }

    public async Task UpdateInvoiceAsync(Invoice invoice)
    {
        _dataContext.Invoice.Update(invoice);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteInvoiceAsync(int id)
    {
        var invoice = await _dataContext.Invoice.FindAsync(id);
        if (invoice != null)
        {
            _dataContext.Invoice.Remove(invoice);
            await _dataContext.SaveChangesAsync();
        }
    }
}