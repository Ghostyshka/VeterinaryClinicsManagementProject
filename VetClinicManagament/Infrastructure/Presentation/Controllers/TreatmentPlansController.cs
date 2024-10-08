using AutoMapper;
using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentPlansController : BaseController
{
    private readonly ITreatmentPlanService _treatmentPlanService;
    private readonly IMapper _mapper;

    public TreatmentPlansController(
    ITreatmentPlanService treatmentPlanService,
    IMapper mapper,
    IConfiguration configuration,
    ILogger<TreatmentPlansController> logger
) : base(configuration, logger)
    {
        _treatmentPlanService = treatmentPlanService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreatmentPlanDto>>> GetTreatmentPlans()
    {
        var treatmentPlans = await _treatmentPlanService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<TreatmentPlanDto>>(treatmentPlans));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TreatmentPlanDto>> GetTreatmentPlan(int id)
    {
        var treatmentPlan = await _treatmentPlanService.GetByIdAsync(id);
        if (treatmentPlan == null)
            return NotFound();

        return Ok(_mapper.Map<TreatmentPlanDto>(treatmentPlan));
    }

    [HttpPost]
    public async Task<ActionResult> AddTreatmentPlan(TreatmentPlanDto treatmentPlanDto)
    {
        var result = await _treatmentPlanService.AddAsync(treatmentPlanDto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTreatmentPlan(int id, TreatmentPlanDto updatedTreatmentPlan)
    {
        if (id != updatedTreatmentPlan.PlanId)
            return BadRequest();

        await _treatmentPlanService.UpdateAsync(updatedTreatmentPlan);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTreatmentPlan(int id) 
    {
        await _treatmentPlanService.DeleteAsync(id);
        return NoContent();
    }
}