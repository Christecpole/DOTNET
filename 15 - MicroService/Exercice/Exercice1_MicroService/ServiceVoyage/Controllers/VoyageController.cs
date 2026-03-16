using Microsoft.AspNetCore.Mvc;
using ServiceVoyage.Dto;
using ServiceVoyage.Service;

namespace ServiceVoyage.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class VoyageController : ControllerBase
    {
        private readonly IService<VoyageSend, VoyageReceive> service;

        public VoyageController(IService<VoyageSend, VoyageReceive> service)
        {
            this.service = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] VoyageReceive send)
        {
            return CreatedAtAction(nameof(Create),service.Create(send));
        }
    }
}
