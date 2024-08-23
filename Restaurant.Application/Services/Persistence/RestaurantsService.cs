using Restaurant.Application.Contracts;
using Restaurant.Application.Interfaces.Persistence;
using Restaurant.Application.Interfaces.Services;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Services.Persistence;

public class RestaurantsService(IRestaurantRepository restaurantRepository) : IRestaurantsService
{
    public async Task<List<Restaurants>> GetAllRestaurants()
    {
        return await restaurantRepository.GetAllAsync();
    }

    public async Task<List<Restaurants>> GetAllRestaurantsWithMenu()
    {
        return await restaurantRepository.GetAllWithMenuAsync();
    }

    public async Task<Restaurants?> GetRestaurantById(Guid id)
    {
        return await restaurantRepository.GetByIdAsync(id);
    }

    public async Task<Guid> CreateRestaurant(RestaurantRequest request)
    {
        var restaurant = new Restaurants
        {
            Name = request.Name,
            Description = request.Description
        };
        
        return await restaurantRepository.CreateAsync(restaurant);
    }

    public async Task<Guid> UpdateRestaurant(Guid id, RestaurantRequest request)
    {
        var existingRestaurant = await restaurantRepository.GetByIdAsync(id);
        
        if (existingRestaurant == null)
        {
            throw new KeyNotFoundException($"Restaurant with id {id} not found");
        }
        
        existingRestaurant.Name = request.Name;
        existingRestaurant.Description = request.Description;
        
        await restaurantRepository.UpdateAsync(existingRestaurant);
        
        return id;
    }

    public async Task<Guid> DeleteRestaurant(Guid id)
    {
        return await restaurantRepository.DeleteAsync(id);
    }
}