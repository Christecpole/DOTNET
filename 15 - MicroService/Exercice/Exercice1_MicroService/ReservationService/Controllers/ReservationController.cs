using Microsoft.AspNetCore.Mvc;
using ReservationService.Dtos;
using ReservationService.Models;
using ReservationService.Services;

namespace ReservationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {

        private readonly IService<ReservationSend,ReservationReceive> service;

        public ReservationController (IService<ReservationSend,ReservationReceive> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await service.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservationReceive receive)
        {
            return Ok(await service.Create(receive));
        }
    }
}
