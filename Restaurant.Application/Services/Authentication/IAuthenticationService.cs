using Restaurant.Application.Contracts;

namespace Restaurant.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> RegisterUserAsync(RegisterRequest registerRequest);
    Task<AuthenticationResponse> LoginUserAsync(LoginRequest loginRequest);
}