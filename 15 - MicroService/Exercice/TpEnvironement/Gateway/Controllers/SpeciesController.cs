using Gateway.Dto;
using Gateway.Filter;
using Gateway.RestClient;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[Route("api/[controller]")]
[ApiController]
[RequireValidToken]
public class SpeciesController : ControllerBase
{
    
    private readonly Client<SpeciesResponseDto,SpeciesDto> speciesClient;
 

    public SpeciesController()
    {
        speciesClient = new Client<SpeciesResponseDto, SpeciesDto>("http://localhost:5128/api/Species");
    }

    [HttpGet]
    public async  Task<IActionResult> GetAll()
    {
        return Ok(await speciesClient.GetRequestList(""));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await speciesClient.GetRequest("/"+id));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SpeciesDto dto)
    {
        return Ok( await speciesClient.PostRequest("",dto));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SpeciesUpdateDto dto)
    {
        return Ok(await speciesClient.PutRequest("", dto));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await speciesClient.DeleteRequest("/" + id));
    }

}