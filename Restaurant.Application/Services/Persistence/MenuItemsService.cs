using Restaurant.Application.Contracts;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Application.Interfaces.Services;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Services.Persistence;

public class MenuItemsService(IMenuItemRepository menuItemRepository) : IMenuItemsService
{
    public async Task<List<MenuItem>> GetAllMenuItems()
    {
        return await menuItemRepository.GetAllAsync();
    }

    public async Task<MenuItem?> GetMenuItemById(Guid id)
    {
        return await menuItemRepository.GetByIdAsync(id);
    }

    public async Task<Guid> CreateMenuItem(MenuItemRequest request)
    {
        var menuItem = new MenuItem()
        {
            RestaurantId = request.RestaurantId,
            Name = request.Name,
            Price = request.Price,
            Category = request.Category,
        };
        
        return await menuItemRepository.CreateAsync(menuItem);
    }

    public async Task<Guid> UpdateMenuItem(Guid id, MenuItemRequest request)
    {
        var existingMenuItem = await menuItemRepository.GetByIdAsync(id);
        
        if (existingMenuItem == null)
        {
            throw new KeyNotFoundException($"MenuItem with id {id} not found");
        }
        
        existingMenuItem.Name = request.Name;
        existingMenuItem.Category = request.Category;
        existingMenuItem.Price = request.Price;
        existingMenuItem.RestaurantId = request.RestaurantId;
        
        await menuItemRepository.UpdateAsync(existingMenuItem);
        
        return id;
    }

    public async Task<Guid> DeleteMenuItem(Guid id)
    {
        return await menuItemRepository.DeleteAsync(id);
    }
}