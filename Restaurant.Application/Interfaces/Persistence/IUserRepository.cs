using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task<ApplicationUser?> GetByEmailAsync(string email);
    Task<Guid> CreateAsync(ApplicationUser user);
}