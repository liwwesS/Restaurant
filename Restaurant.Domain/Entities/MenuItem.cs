namespace Restaurant.Domain.Entities;

public class MenuItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Category { get; set; } = default!;
    
    public Guid RestaurantId { get; set; }
}