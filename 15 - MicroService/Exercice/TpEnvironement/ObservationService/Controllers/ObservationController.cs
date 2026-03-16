using Microsoft.AspNetCore.Mvc;
using ObservationService.Service;
using ObservationService.Dto;
using ObservationService.Service;

namespace ObservationService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObservationController : ControllerBase
{

    private readonly IServiceObservation _service;

    public ObservationController(IServiceObservation service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.Get());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.Get(id));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ObservationDto dto)
    {
        return Ok(await _service.Create(dto));
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetByUser()
    {
        string token =  Request.Headers["Authorization"].FirstOrDefault();
        
        return Ok(await _service.GetByUser(token));
    }
    
    [HttpGet("by-location/{location}")]
    public async Task<IActionResult> GetByLocation(string location)
    {
        return Ok(_service.GetByLocation(location));
    }
    
    [HttpGet("by-Species/{speciesId}")]
    public async Task<IActionResult> GetByLocation(int speciesId)
    {
        return Ok(await _service.GetBySpecies(speciesId));
    }

    
}