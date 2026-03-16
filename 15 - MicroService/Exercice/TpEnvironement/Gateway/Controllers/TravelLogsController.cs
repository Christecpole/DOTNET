using Gateway.Dto;
using Gateway.Filter;
using Gateway.RestClient;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[Route("api/[controller]")]
[ApiController]
[RequireValidToken]
public class TravelLogsController : ControllerBase
{
    private readonly Client<TravelLogsResponseDto,TravelLogsDto> _client;

    public TravelLogsController()
    {
        _client = new Client<TravelLogsResponseDto, TravelLogsDto>("http://localhost:5270/api/TravelLogs");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _client.GetRequestList(""));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok( await _client.GetRequest("/"+id));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TravelLogsDto dto)
    {
        return Ok(await _client.PostRequest("",dto));
    }
}