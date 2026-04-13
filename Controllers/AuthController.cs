using DevTrackAPI.DTOs.AuthDTOs;
using DevTrackAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public  AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var success = await _authService.RegisterAsync(registerDto);
        return success ? Ok("Registered successfullt") : Conflict("Email already registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await _authService.LoginAsync(loginDto);
        return token == null ? Unauthorized("Invalid credentials") : Ok(token);
    }

}