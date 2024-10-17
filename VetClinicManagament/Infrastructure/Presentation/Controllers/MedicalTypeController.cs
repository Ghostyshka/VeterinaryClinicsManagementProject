using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalTypeController : BaseController
{
    private readonly IMedicalTypeService _medicalTypeService;

    public MedicalTypeController(
    IMedicalTypeService medicalTypeService,
    IConfiguration configuration,
    ILogger<MedicalTypeController> logger
) : base(configuration, logger)
    {
        _medicalTypeService = medicalTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var medicalTypes = await _medicalTypeService.GetAllMedicalTypesAsync();
        return Ok(medicalTypes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var medicalType = await _medicalTypeService.GetMedicalTypeByIdAsync(id);
        if (medicalType == null)
        {
            return NotFound();
        }
        return Ok(medicalType);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MedicalTypeDto medicalTypeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _medicalTypeService.AddMedicalTypeAsync(medicalTypeDto);
        return CreatedAtAction(nameof(GetById), new { id = medicalTypeDto.TypeId }, medicalTypeDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MedicalTypeDto medicalTypeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _medicalTypeService.UpdateMedicalTypeAsync(id, medicalTypeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _medicalTypeService.DeleteMedicalTypeAsync(id);
        return NoContent();
    }
}