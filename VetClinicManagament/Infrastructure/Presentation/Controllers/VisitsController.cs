using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/[controller]")]
//[Authorize]
[ApiController]
public class VisitsController : BaseController
{
    private readonly IVisitService _visitService;

    public VisitsController(
        IVisitService visitService,
        IConfiguration configuration,
        ILogger<VisitsController> logger
    ) : base(configuration, logger)
    {
        _visitService = visitService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var visits = await _visitService.GetAllAsync();
        return Ok(visits);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var visit = await _visitService.GetByIdAsync(id);
        if (visit == null)
            return NotFound();

        return Ok(visit);
    }

    [HttpPost]
    public async Task<IActionResult> Add(VisitDto visitDto)
    {
        var visit = await _visitService.AddAsync(visitDto);
        return Ok(visit);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VisitDto visitDto)
    {
        var updatedVisit = await _visitService.UpdateAsync(visitDto);
        if (updatedVisit == null)
            return NotFound();

        return Ok(updatedVisit);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _visitService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}