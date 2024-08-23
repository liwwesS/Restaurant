namespace Restaurant.Application.Contracts;

public record MenuItemResponse(
    Guid Id,
    decimal Price,
    string Name = default!,
    string Category = default!
    );
