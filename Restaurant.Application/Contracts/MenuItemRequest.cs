namespace Restaurant.Application.Contracts;

public record MenuItemRequest(
    Guid RestaurantId,
    decimal Price,
    string Name = default!,
    string Category = default!
    );