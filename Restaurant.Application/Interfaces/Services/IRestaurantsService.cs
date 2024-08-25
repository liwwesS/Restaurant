using Restaurant.Application.Contracts;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces.Services;

public interface IRestaurantsService
{
    Task<List<Restaurants>> GetAllRestaurants();
    Task<Restaurants?> GetRestaurantById(Guid id);
    Task<Guid> CreateRestaurant(RestaurantRequest request);
    Task<Guid> UpdateRestaurant(Guid id, RestaurantRequest request);
    Task<Guid> DeleteRestaurant(Guid id);
}