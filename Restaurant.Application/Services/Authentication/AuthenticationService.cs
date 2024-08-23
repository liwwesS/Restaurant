using Restaurant.Application.Contracts;
using Restaurant.Application.Interfaces.Authentication;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Services.Authentication;

public class AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IAuthenticationService
{
    public async Task<AuthenticationResponse> RegisterUserAsync(RegisterRequest registerRequest)
    {
        var existingUser = await userRepository.GetByEmailAsync(registerRequest.Email);
        
        if (existingUser != null)
        {
            return new AuthenticationResponse(
                Success: false
            );
        }

        var user = new ApplicationUser
        {
            Name = registerRequest.Name,
            Email = registerRequest.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password)
        };

        await userRepository.CreateAsync(user);
        
        return new AuthenticationResponse(
            Success: true,
            UserId: user.Id,
            UserName: user.Name,
            Email: user.Email
        );
    }

    public async Task<AuthenticationResponse> LoginUserAsync(LoginRequest loginRequest)
    {
        var user = await userRepository.GetByEmailAsync(loginRequest.Email);
        
        if (user == null)
        {
            return new AuthenticationResponse(
                Success: false
            );
        }

        var isValidPassword = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password);

        if (!isValidPassword)
        {
            return new AuthenticationResponse(
                Success: false
            );
        }

        var token = GenerateJwtToken(user);

        return new AuthenticationResponse(
            Success: true,
            Token: token,
            UserId: user.Id,
            UserName: user.Name,
            Email: user.Email
        );
    }
    
    private string GenerateJwtToken(ApplicationUser user)
    {
        return jwtTokenGenerator.GenerateToken(user);
    }
}