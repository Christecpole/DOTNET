using AuthMicroService.Dtos;
using AuthMicroService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthMicroService.Controllers
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

        /// <summary>
        /// Authentifie un utilisateur et retourne un JWT
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto) 
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var reponse = _authService.Authenticate(dto);
            return Ok(reponse);
        }
        
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto) 
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var reponse = _authService.Register(dto);
            return Ok(reponse);
        }


        [Authorize] 
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            
            if(username == null)
            {
                throw new UnauthorizedAccessException("Token invalide ou corrompu.");
            }
            
            return Ok(username);

        }

        [HttpGet("/ping")]
        [Authorize]
        public IActionResult Ping()
        {
            return Ok("Token Valide");
        }

    }
}
