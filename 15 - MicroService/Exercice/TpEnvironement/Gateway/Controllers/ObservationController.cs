using Gateway.Dto;
using Gateway.Filter;
using Gateway.RestClient;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[Route("api/[controller]")]
[ApiController]
[RequireValidToken]
public class ObservationController : ControllerBase
{
    private readonly Client<ObservationResponseDto, ObservationDto> observationClient;

    public ObservationController()
    {
        observationClient = new Client<ObservationResponseDto, ObservationDto>("http://localhost:5169/api/Observation");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await observationClient.GetRequestList(""));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await observationClient.GetRequest("/"+id));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ObservationDto dto)
    {
        return Ok(await observationClient.PostRequest("",dto));
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetByUser()
    {
        string token =  Request.Headers["Authorization"].FirstOrDefault();
        
        return Ok(await observationClient.GetRequestWithToken("/me",token));
    }
    
    [HttpGet("by-location/{location}")]
    public async Task<IActionResult> GetByLocation(string location)
    {
        return Ok(observationClient.GetRequest("/by-location/"+location));
    }
    
    [HttpGet("by-Species/{speciesId}")]
    public async  Task<IActionResult> GetByLocation(int speciesId)
    {
        return Ok( await observationClient.GetRequest("/by-location/"+speciesId));
    }
}