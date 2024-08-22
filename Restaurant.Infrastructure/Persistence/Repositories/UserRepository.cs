using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Contracts;
using Restaurant.Application.Interfaces.Authentication;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserRepository(ApplicationDbContext context, IJwtTokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    private async Task<ApplicationUser?> FindUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    public async Task<RegistrationResponse> RegisterUserAsync(RegisterRequest registerRequest)
    {
        var getUser = await FindUserByEmail(registerRequest.Email);
        
        if (getUser != null)
            return new RegistrationResponse(false, "User already exist!");

        _context.Users.Add(new ApplicationUser()
        {
            Name = registerRequest.Name,
            Email = registerRequest.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password) 
        });
        await _context.SaveChangesAsync();
        
        return new RegistrationResponse(true, "Registration completed!");
    }

    public async Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest)
    {
        var user = await FindUserByEmail(loginRequest.Email);
        
        if (user == null)
            return new LoginResponse(false, "User not found!");

        var checkPassword = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password);

        if (checkPassword)
            return new LoginResponse(true, "Login successfully!", _jwtTokenGenerator.GenerateToken(user));
        
        return new LoginResponse(false, "Invalid credential!");
    }
}