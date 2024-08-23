using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces.Services;

public interface IMenuItemsService
{
    Task<List<MenuItem>> GetAllMenuItems();
    Task<MenuItem?> GetMenuItemById(Guid id);
    Task<Guid> CreateMenuItem(MenuItem item);
    Task<Guid> UpdateMenuItem(MenuItem item);
    Task<Guid> DeleteMenuItem(Guid id);
}