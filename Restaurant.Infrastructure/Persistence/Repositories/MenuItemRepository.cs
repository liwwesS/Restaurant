using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence.Repositories;

public class MenuItemRepository(ApplicationDbContext context) : IMenuItemRepository
{
    public async Task<List<MenuItem>> GetAllAsync()
    {
        return await context.MenuItems.ToListAsync();
    }
    
    public async Task<MenuItem?> GetByIdAsync(Guid id)
    {
        return await context.MenuItems
            .Where(m => m.Id == id)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Guid> CreateAsync(MenuItem menuItem)
    {
        await context.MenuItems.AddAsync(menuItem);
        await context.SaveChangesAsync();
        
        return menuItem.Id;
    }

    public async Task<Guid> UpdateAsync(MenuItem menuItem)
    {
        await context.MenuItems
            .Where(m => m.Id == menuItem.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => menuItem.Name)
                .SetProperty(b => b.Category, b => menuItem.Category)
                .SetProperty(b => b.Price, b => menuItem.Price)
                .SetProperty(b => b.RestaurantId, b => menuItem.RestaurantId));

        return menuItem.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        await context.MenuItems
            .Where(m => m.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}