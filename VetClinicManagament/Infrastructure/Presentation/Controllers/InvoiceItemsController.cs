using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
//[Authorize]
[Route("api/[controller]")]
public class InvoiceItemsController : BaseController
{
    private readonly IInvoiceItemService _invoiceItemService;

    public InvoiceItemsController(
    IInvoiceItemService invoiceItemService,
    IConfiguration configuration,
    ILogger<InvoiceItemsController> logger
) : base(configuration, logger)
    {
        _invoiceItemService = invoiceItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetInvoiceItems()
    {
        var items = await _invoiceItemService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoiceItem(int id)
    {
        var item = await _invoiceItemService.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> AddInvoiceItem([FromBody] InvoiceItemDto invoiceItem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdItem = await _invoiceItemService.AddAsync(invoiceItem);
        return Ok(createdItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInvoiceItem(int id, [FromBody] InvoiceItemUpdateDto invoiceItemUpdated)
    {
        if (id != invoiceItemUpdated.ItemId || !ModelState.IsValid)
        {
            return BadRequest();
        }

        var updatedItem = await _invoiceItemService.UpdateAsync(invoiceItemUpdated);
        return Ok(updatedItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoiceItem(int id)
    {
        var deleted = await _invoiceItemService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}