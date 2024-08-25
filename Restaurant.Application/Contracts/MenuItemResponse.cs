namespace Restaurant.Application.Contracts;

public record MenuItemResponse(
    Guid Id,
    Guid RestaurantId,
    decimal Price,
    string Name = default!,
    string Category = default!
    );
