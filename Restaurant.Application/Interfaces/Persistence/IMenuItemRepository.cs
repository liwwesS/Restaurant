using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces.Persistence;

public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetAllAsync();
    Task<MenuItem?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(MenuItem menuItem);
    Task<Guid> UpdateAsync(MenuItem menuItem);
    Task<Guid> DeleteAsync(Guid id);
}