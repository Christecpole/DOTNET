using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.DTOs;
using TodoListApi.Services;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/auth/register
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterDto dto)
        {
            var token = _authService.Register(dto);
            return Created("", new { token });
        }

        // POST api/auth/login
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            var token = _authService.Login(dto);
            return Ok(new { token });
        }
    }
}
