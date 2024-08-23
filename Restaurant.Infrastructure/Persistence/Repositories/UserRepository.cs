using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<ApplicationUser?> GetByEmailAsync(string email)
    {
        return await context.Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<Guid> CreateAsync(ApplicationUser user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user.Id;
    }
}