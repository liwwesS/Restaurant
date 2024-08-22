using Restaurant.Application.Contracts;

namespace Restaurant.Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task<RegistrationResponse> RegisterUserAsync(RegisterRequest registerRequest);
    Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest);
}