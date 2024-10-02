using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
//[Authorize]       //commented for testing
[Route("api/[controller]")]
public class ClientsController : BaseController
{
    private readonly IClientService _clientService;

    public ClientsController(
        IClientService clientService,
        IConfiguration configuration,
        ILogger<ClientsController> logger
    ) : base(configuration, logger)
    {
        _clientService = clientService;
    }

    [HttpPost("animal")]
    public async Task<IActionResult> AddAnimal(AddAnimalDto newAnimal)
    {
        var animalId = await _clientService.AddAnimalAsync(newAnimal);
        return Ok(animalId);
    }

    [HttpPut("updateAnimal/{animalId}")]
    public async Task<IActionResult> UpdateUser(int animalId, AnimalUpdateDto updatedAnimal)
    {
        await _clientService.UpdatedAnimalAsync(animalId, updatedAnimal);
        return NoContent();
    }

    [HttpDelete("deleteAnimal/{animalId}")]
    public async Task<IActionResult> DeleteAnimal(int animalId)
    {
        await _clientService.DeleteAnimalAsync(animalId);
        return NoContent();
    }

    [HttpPost("specie")]
    public async Task<IActionResult> AddSpecieAsync(AddSpecieDto newSpecie)
    {
        var animalId = await _clientService.AddSpecieAsync(newSpecie);
        return Ok(newSpecie);
    }

    [HttpPost("addNewBreed")]
    public async Task<IActionResult> AddBreedAsync(AddBreedDto newBreed)
    {
        var animalId = await _clientService.AddBreedAsync(newBreed);
        return Ok(newBreed);
    }

    [HttpPost("color")]
    public async Task<IActionResult> AddColorAsync(AddColorDto newColor)
    {
        var animalId = await _clientService.AddColorAsync(newColor);
        return Ok(newColor);
    }
}