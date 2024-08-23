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

    public async Task<Guid> CreateMenuItem(MenuItem item)
    {
        return await menuItemRepository.CreateAsync(item);
    }

    public async Task<Guid> UpdateMenuItem(MenuItem item)
    {
        return await menuItemRepository.UpdateAsync(item);
    }

    public async Task<Guid> DeleteMenuItem(Guid id)
    {
        return await menuItemRepository.DeleteAsync(id);
    }
}