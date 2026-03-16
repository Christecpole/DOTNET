using Gateway.Dto;
using Gateway.Filter;
using Gateway.RestClient;
using Microsoft.AspNetCore.Mvc;


namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireValidToken]

    public class OrderController : ControllerBase
    {
        private readonly Client<OrderSend, OrderReceive> _client;


        public OrderController()
        {
            _client = new Client<OrderSend, OrderReceive>("http://localhost:5035/api/Order");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _client.GetRequestList(""));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _client.GetRequest("/"+id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderReceive receive)
        {
            return Ok(await _client.PostRequest("",receive));
        }
    }
}
