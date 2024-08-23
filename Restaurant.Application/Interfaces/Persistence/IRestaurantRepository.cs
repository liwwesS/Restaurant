using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces.Persistence;

public interface IRestaurantRepository
{
    Task<List<Restaurants>> GetAllAsync();
    Task<List<Restaurants>> GetAllWithMenuAsync();
    Task<Restaurants?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(Restaurants restaurant);
    Task<Guid> UpdateAsync(Restaurants restaurant);
    Task<Guid> DeleteAsync(Guid id);
}