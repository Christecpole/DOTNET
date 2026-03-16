using Microsoft.AspNetCore.Mvc;
using SpecieMicroService.Dto;
using SpecieMicroService.Service;

namespace SpecieMicroService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpeciesController : ControllerBase
{

    private readonly ISpecieService _service;

    public SpeciesController(ISpecieService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.Get());
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_service.Get(id));
    }
    [HttpPost]
    public IActionResult Create([FromBody] SpeciesDto dto)
    {
        return Ok(_service.Create(dto));
    }
    [HttpPut]
    public IActionResult Update([FromBody] SpeciesUpdateDto dto)
    {
        return Ok(_service.Update(dto));
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_service.Delete(id));
    }
    
}