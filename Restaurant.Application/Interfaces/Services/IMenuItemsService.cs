using Restaurant.Application.Contracts;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces.Services;

public interface IMenuItemsService
{
    Task<List<MenuItem>> GetAllMenuItems();
    Task<MenuItem?> GetMenuItemById(Guid id);
    Task<Guid> CreateMenuItem(MenuItemRequest request);
    Task<Guid> UpdateMenuItem(Guid id, MenuItemRequest request);
    Task<Guid> DeleteMenuItem(Guid id);
}