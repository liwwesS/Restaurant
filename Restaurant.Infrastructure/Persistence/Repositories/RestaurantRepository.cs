using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence.Repositories;

public class RestaurantRepository(ApplicationDbContext context) : IRestaurantRepository
{
    public async Task<List<Restaurants>> GetAllAsync()
    {
        return await context.Restaurants.ToListAsync();
    }
    
    public async Task<Restaurants?> GetByIdAsync(Guid id)
    {
        return await context.Restaurants
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Guid> CreateAsync(Restaurants restaurant)
    {
        await context.Restaurants.AddAsync(restaurant);
        await context.SaveChangesAsync();
        
        return restaurant.Id;
    }

    public async Task<Guid> UpdateAsync(Restaurants restaurant)
    {
        await context.Restaurants
            .Where(r => r.Id == restaurant.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => restaurant.Name)
                .SetProperty(b => b.Description, b => restaurant.Description));

        return restaurant.Id;
    }
    
    public async Task<Guid> DeleteAsync(Guid id)
    {
        await context.Restaurants
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}