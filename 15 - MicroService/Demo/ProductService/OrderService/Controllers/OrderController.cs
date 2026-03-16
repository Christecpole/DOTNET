using Microsoft.AspNetCore.Mvc;
using OrderService.Dto;
using OrderService.Service;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderSend, OrderReceive> _service;

        public OrderController(IService<OrderSend, OrderReceive> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetById(id);
            if(order is null)
            {
                return NotFound("order Not found");
            }
            return Ok(order);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderReceive receive)
        {
            var order = await _service.Create(receive);
            return CreatedAtAction(nameof(Create), order);

        }
    }
}
