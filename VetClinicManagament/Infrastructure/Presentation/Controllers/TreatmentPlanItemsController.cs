using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentPlanItemController : BaseController
{
    private readonly ITreatmentPlanItemService _treatmentPlanItemService;
    private readonly IMapper _mapper;

    public TreatmentPlanItemController(
    ITreatmentPlanItemService treatmentPlanItemService,
    IMapper mapper,
    IConfiguration configuration,
    ILogger<TreatmentPlanItemController> logger
) : base(configuration, logger)
    {
        _treatmentPlanItemService = treatmentPlanItemService;
        _mapper = mapper;
    }

    [HttpGet("{planId}")]
    public async Task<ActionResult<IEnumerable<TreatmentPlanItemDto>>> GetTreatmentPlanItems(int planId)
    {
        var items = await _treatmentPlanItemService.GetItemsByPlanIdAsync(planId);
        return Ok(_mapper.Map<IEnumerable<TreatmentPlanItemDto>>(items));
    }

    [HttpPost]
    public async Task<IActionResult> AddTreatmentPlanItem([FromBody] TreatmentPlanItemDto addDto)
    {
        var item = _mapper.Map<TreatmentPlanItem>(addDto);
        await _treatmentPlanItemService.AddAsync(item);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTreatmentPlanItem(int id)
    {
        await _treatmentPlanItemService.DeleteAsync(id);
        return Ok();
    }
}
