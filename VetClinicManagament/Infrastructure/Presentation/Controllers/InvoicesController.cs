using Domain.Entities;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Presentation.Controllers;

[ApiController]
//[Authorize]       //commented for testing
[Route("api/invoices")]
public class InvoicesController : ControllerBase
{
    private readonly InvoiceService _invoiceService;

    public InvoicesController(InvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInvoices()
    {
        var invoices = await _invoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (invoice == null) return NotFound();
        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> AddInvoice([FromBody] InvoiceDto newInvoice)
    {
        var result = await _invoiceService.AddInvoiceAsync(newInvoice);
        //return CreatedAtAction(nameof(GetInvoice), new { id = result.InvoiceId }, result);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceDto updatedInvoice)
    {
        await _invoiceService.UpdateInvoiceAsync(updatedInvoice);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        await _invoiceService.DeleteInvoiceAsync(id);
        return NoContent();
    }
}