using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Contracts;
using Restaurant.Application.Services.Authentication;

namespace Restaurant.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest loginRequest)
    {
        var result = await authenticationService.LoginUserAsync(loginRequest);
        
        if (!result.Success)
        {
            return Unauthorized(result);
        }
        
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(1)
        };

        Response.Cookies.Append("super-cookies", result.Token, cookieOptions);
        
        return Ok(result);
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResponse>> Register(RegisterRequest registerRequest)
    {
        var result = await authenticationService.RegisterUserAsync(registerRequest);
        
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("super-cookies");

        return NoContent();
    }
}