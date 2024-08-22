using Microsoft.Extensions.Logging;
using Restaurant.Application.Contracts;
using Restaurant.Application.Interfaces.Authentication;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ILogger<AuthenticationService> _logger;
    public AuthenticationService(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        ILogger<AuthenticationService> logger)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _logger = logger;
    }
    
    public async Task<AuthenticationResponse> RegisterUserAsync(RegisterRequest registerRequest)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(registerRequest.Email);
        
        if (existingUser != null)
        {
            _logger.LogWarning("Attempt to register an already existing user with email: {Email}", registerRequest.Email);
            return new AuthenticationResponse(
                Success: false,
                Message: "User already exists!"
            );
        }

        var user = new ApplicationUser
        {
            Name = registerRequest.Name,
            Email = registerRequest.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password)
        };

        await _userRepository.AddUserAsync(user);
        
        _logger.LogInformation("New user registered with email: {Email}", registerRequest.Email);
        
        return new AuthenticationResponse(
            Success: true,
            Message: "Registration completed!",
            UserId: user.Id,
            UserName: user.Name,
            Email: user.Email
        );
    }

    public async Task<AuthenticationResponse> LoginUserAsync(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserByEmailAsync(loginRequest.Email);
        
        if (user == null)
        {
            _logger.LogWarning("Login attempt with non-existing email: {Email}", loginRequest.Email);
            return new AuthenticationResponse(
                Success: false,
                Message: "User not found!"
            );
        }

        var isValidPassword = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password);

        if (!isValidPassword)
        {
            _logger.LogWarning("Invalid login attempt for email: {Email}", loginRequest.Email);
            return new AuthenticationResponse(
                Success: false,
                Message: "Invalid credentials!"
            );
        }

        var token = GenerateJwtToken(user);
        _logger.LogInformation("User logged in successfully: {Email}", user.Email);

        return new AuthenticationResponse(
            Success: true,
            Message: "Login successful!",
            Token: token,
            UserId: user.Id,
            UserName: user.Name,
            Email: user.Email
        );
    }
    
    private string GenerateJwtToken(ApplicationUser user)
    {
        return _jwtTokenGenerator.GenerateToken(user);
    }
}