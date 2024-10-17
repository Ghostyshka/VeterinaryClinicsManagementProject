using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Entities;
using Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;
using Domain.Models.Dtos;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceTypesController : BaseController
{
    private readonly IServiceTypeService _serviceTypeService;
    private readonly IMapper _mapper;

    public ServiceTypesController(
    IServiceTypeService serviceTypeService,
    IMapper mapper,
    IConfiguration configuration,
    ILogger<ServiceTypesController> logger
) : base(configuration, logger)
    {
        _serviceTypeService = serviceTypeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceTypeDto>>> GetServiceTypes()
    {
        var serviceTypes = await _serviceTypeService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ServiceTypeDto>>(serviceTypes));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceTypeDto>> GetServiceType(int id)
    {
        var serviceType = await _serviceTypeService.GetByIdAsync(id);
        if (serviceType == null)
            return NotFound();

        return Ok(_mapper.Map<ServiceTypeDto>(serviceType));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceTypeDto>> CreateServiceType(ServiceTypeDto serviceTypeDto)
    {
        var serviceType = _mapper.Map<ServiceType>(serviceTypeDto);
        await _serviceTypeService.CreateAsync(serviceType);
        return CreatedAtAction(nameof(GetServiceType), new { id = serviceType.ServiceTypeId }, serviceTypeDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateServiceType(int id, ServiceTypeDto serviceTypeDto)
    {
        if (id != serviceTypeDto.ServiceTypeId)
            return BadRequest();

        var serviceType = _mapper.Map<ServiceType>(serviceTypeDto);
        await _serviceTypeService.UpdateAsync(serviceType);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServiceType(int id)
    {
        await _serviceTypeService.DeleteAsync(id);
        return NoContent();
    }
}