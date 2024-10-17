using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalsController : BaseController
{
    private readonly IMedicalService _medicalsService;

    public MedicalsController(
    IMedicalService medicalsService,
    IConfiguration configuration,
    ILogger<MedicalsController> logger
) : base(configuration, logger)
    {
        _medicalsService = medicalsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var medicals = await _medicalsService.GetAllAsync();
        return Ok(medicals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var medical = await _medicalsService.GetByIdAsync(id);
        if (medical == null) return NotFound();
        return Ok(medical);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] MedicalDto medicalDto)
    {
        await _medicalsService.AddAsync(medicalDto);
        return CreatedAtAction(nameof(GetById), new { id = medicalDto.MedicalId }, medicalDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MedicalDto medical)
    {
        if (id != medical.MedicalId) return BadRequest();

        await _medicalsService.UpdateAsync(medical);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _medicalsService.DeleteAsync(id);
        return NoContent();
    }
}