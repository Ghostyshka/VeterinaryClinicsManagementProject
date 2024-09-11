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
[Route("api/[controller]")]
public class ClientController : BaseController
{
    private readonly IClientService _clientService;

    public ClientController(
        IClientService clientService,
        IConfiguration configuration,
        ILogger<ClientController> logger
    ) : base(configuration, logger)
    {
        _clientService = clientService;
    }

    //[HttpPost("addNewAnimal")]
    //public async Task<IActionResult> AddAnimal([FromBody] AddAnimalDto newAnimal)
    //{
    //    var animalId = await _clientService.AddAnimalAsync(newAnimal);
    //    return Ok(animalId);
    //}

    //[HttpPost("addVaccineToAnimal")]
    //public async Task<IActionResult> AddVaccinationToAnimal([FromBody] AddVaccinationDto addVaccinationDto)
    //{
    //    var result = await _clientService.AddVaccinationToAnimalAsync(addVaccinationDto);
    //    return result ? Ok("Vaccination added successfully.") : StatusCode(500, "An error occurred while adding the vaccination.");
    //}
}   