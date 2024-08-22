using Restaurant.Application.Contracts;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
    Task AddUserAsync(ApplicationUser user);
}