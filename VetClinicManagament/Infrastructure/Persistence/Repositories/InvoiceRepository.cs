using Domain.Entities;
using Persistence.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Dtos;

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

    public async Task<InvoiceVisitDetailsDto> GetInvoiceDetailsAsync(int invoiceId)
    {
        var invoice = await _dataContext.Invoice
            .Include(i => i.Visit)
            .ThenInclude(v => v.User)
            .Include(i => i.Visit)
            .ThenInclude(v => v.Employee)
            .Include(i => i.InvoiceItems)
            .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);

        if (invoice == null)
        {
            throw new Exception("Invoice not found");
        }

        var invoiceDetailsDto = new InvoiceVisitDetailsDto
        {
            InvoiceId = invoice.InvoiceId,
            VisitId = invoice.VisitId,
            VisitDate = invoice.Visit.DataOfVisit,
            UserName = invoice.Visit.User.FullName,
            EmployeeName = invoice.Visit.Employee.EmployeeFullName,
            InvoiceStatus = invoice.InvoiceStatus,
            CreatedAt = invoice.CreatedAt,
            UpdatedAt = invoice.UpdatedAt,
            InvoiceItems = invoice.InvoiceItems.Select(item => new InvoiceItemDto
            {
                ItemType = item.ItemType
            }).ToList()
        };

        return invoiceDetailsDto;
    }
}