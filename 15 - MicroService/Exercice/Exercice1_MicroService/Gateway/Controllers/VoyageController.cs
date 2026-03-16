using Gateway.Dto;
using Gateway.Dtos;
using Gateway.RestClient;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoyageController : ControllerBase
    {

        private readonly Client<VoyageSend, VoyageReceive> client;

        public VoyageController()
        {
            client = new Client<VoyageSend, VoyageReceive>("http://localhost:8081/api/Voyage");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await client.GetRequestList(""));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await client.GetRequest("/" + id)); ;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VoyageReceive receive)
        {
            return Ok(await client.PostRequest("", receive));
        }

    }
}
