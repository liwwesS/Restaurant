namespace Restaurant.Application.Contracts;

public record RestaurantRequest(
    string Name = default!,
    string Description  = default!
    );