using Gateway.Dtos;
using Gateway.RestClient;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly Client<ReservationSend, ReservationReceive> client;

        public ReservationController()
        {
            client = new Client<ReservationSend, ReservationReceive>("http://localhost:8082/api/Reservation");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await client.GetRequestList(""));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await client.GetRequest("/"+id)); ;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservationReceive receive)
        {
            return Ok(await client.PostRequest("",receive));
        }
    }
}
