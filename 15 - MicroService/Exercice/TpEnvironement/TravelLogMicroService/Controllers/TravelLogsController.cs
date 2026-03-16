using Microsoft.AspNetCore.Mvc;
using TravelLogMicroService.Dto;
using TravelLogMicroService.Service;

namespace TravelLogMicroService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TravelLogsController : ControllerBase
{

    private readonly IServiceTravelLogs _service;

    public TravelLogsController(IServiceTravelLogs service)
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
    public async Task<IActionResult> Create([FromBody] TravelLogsDto dto)
    {
        return Ok(await _service.Create(dto));
    }

    
}