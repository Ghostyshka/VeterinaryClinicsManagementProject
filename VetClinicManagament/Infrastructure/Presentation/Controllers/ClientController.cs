﻿using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
//[Authorize]
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

    [HttpPost("addNewAnimal")]
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

    [HttpPost("addNewSpecie")]
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

    [HttpPost("addNewColor")]
    public async Task<IActionResult> AddColorAsync(AddColorDto newColor)
    {
        var animalId = await _clientService.AddColorAsync(newColor);
        return Ok(newColor);
    }
}