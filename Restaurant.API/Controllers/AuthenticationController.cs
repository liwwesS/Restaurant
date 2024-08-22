using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Contracts;
using Restaurant.Application.Services.Authentication;

namespace Restaurant.API.Controllers;

[Route("auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest loginRequest)
    {
        var result = await _authenticationService.LoginUserAsync(loginRequest);
        
        if (!result.Success)
        {
            return Unauthorized(result);
        }
        
        return Ok(result);
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResponse>> Register(RegisterRequest registerRequest)
    {
        var result = await _authenticationService.RegisterUserAsync(registerRequest);
        
        if (!result.Success)
        {
            return BadRequest(result);
        }
        
        return CreatedAtAction(nameof(Register), new { id = result.UserId }, result);
    }
}