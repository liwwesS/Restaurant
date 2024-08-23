namespace Restaurant.Application.Contracts;

public record RestaurantResponse(
    Guid Id,
    string Name = default!,
    string Description = default!,
    List<MenuItemResponse>? MenuItems = null   
);
    