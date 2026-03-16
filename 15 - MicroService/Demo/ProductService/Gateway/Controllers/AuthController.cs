using Articles.Api.Dtos;
using Gateway.RestClient;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly Client<LoginResponseDto, LoginDto> client;

        public AuthController()
        {
            client = new Client<LoginResponseDto, LoginDto>("http://localhost:5028");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            return Ok(await client.PostRequest("/api/Auth/login", loginDto));
        }

    }
}
