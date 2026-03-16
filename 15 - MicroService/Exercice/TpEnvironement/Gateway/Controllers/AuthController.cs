using AuthMicroService.Dtos;
using Gateway.Dtos;
using Gateway.RestClient;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly Client<LoginResponseDto, LoginDto> client;
    private readonly Client<LoginResponseDto, RegisterDto> registerclient;

    public AuthController()
    {
        client = new Client<LoginResponseDto, LoginDto>("http://localhost:5037/api/Auth");
        registerclient = new Client<LoginResponseDto, RegisterDto>("http://localhost:5037/api/Auth");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        return Ok(await client.PostRequest("/login", loginDto));
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        return Ok(await registerclient.PostRequest("/register", registerDto));
    }
}