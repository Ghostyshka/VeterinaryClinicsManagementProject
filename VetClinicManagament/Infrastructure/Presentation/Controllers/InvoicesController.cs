using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
[Authorize]
[Route("api/invoices")]
public class InvoicesController : BaseController
{
    private readonly IInvoiceService _invoiceService;

    public InvoicesController(
        IInvoiceService invoiceService,
        IConfiguration configuration,
        ILogger<InvoicesController> logger
    ) : base(configuration, logger)
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