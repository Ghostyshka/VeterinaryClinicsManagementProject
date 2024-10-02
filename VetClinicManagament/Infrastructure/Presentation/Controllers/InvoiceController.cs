using Domain.Entities;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Presentation.Controllers;

[ApiController]
//[Authorize]
[Route("api/[controller]")]
//[Route("api/invoices")]
public class InvoiceController : ControllerBase
{
    private readonly InvoiceService _invoiceService;

    public InvoiceController(InvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet("getAllInvoices")]
    public async Task<IActionResult> GetAllInvoices()
    {
        var invoices = await _invoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }

    [HttpGet("getInvoiceById/{id}")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (invoice == null) return NotFound();
        return Ok(invoice);
    }

    [HttpPost("AddInvoice")]
    public async Task<IActionResult> AddInvoice([FromBody] InvoiceDto newInvoice)
    {
        var result = await _invoiceService.AddInvoiceAsync(newInvoice);
        //return CreatedAtAction(nameof(GetInvoice), new { id = result.InvoiceId }, result);
        return Ok(result);
    }

    [HttpPut("updateInvoice/{id}")]
    public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceDto updatedInvoice)
    {
        await _invoiceService.UpdateInvoiceAsync(updatedInvoice);
        return NoContent();
    }

    [HttpDelete("deleteInvoice/{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        await _invoiceService.DeleteInvoiceAsync(id);
        return NoContent();
    }
}