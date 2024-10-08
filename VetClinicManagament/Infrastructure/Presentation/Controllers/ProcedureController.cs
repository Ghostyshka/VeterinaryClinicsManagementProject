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
public class ProcedureController : BaseController
{
    private readonly IProcedureService _serviceService;
    private readonly IMapper _mapper;

    public ProcedureController(
    IProcedureService serviceService,
    IConfiguration configuration,
    IMapper mapper,
    ILogger<ProcedureController> logger
) : base(configuration, logger)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcedureDto>>> GetServices()
    {
        var services = await _serviceService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ProcedureDto>>(services));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProcedureDto>> GetService(int id)
    {
        var service = await _serviceService.GetByIdAsync(id);
        if (service == null)
            return NotFound();

        return Ok(_mapper.Map<ProcedureDto>(service));
    }

    [HttpPost]
    public async Task<ActionResult<ProcedureDto>> CreateService(ProcedureDto serviceDto)
    {
        var service = _mapper.Map<Domain.Entities.Service>(serviceDto);
        await _serviceService.CreateAsync(service);
        return CreatedAtAction(nameof(GetService), new { id = service.ServiceId }, serviceDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateService(int id, ProcedureUpdateDto serviceDto)
    {
        if (id != serviceDto.ServiceId)
            return BadRequest();

        var service = _mapper.Map<Domain.Entities.Service>(serviceDto);
        await _serviceService.UpdateAsync(service);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        await _serviceService.DeleteAsync(id);
        return NoContent();
    }
}
