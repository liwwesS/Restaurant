namespace Restaurant.Domain.Entities;

public class Restaurants
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<MenuItem> MenuItems { get; set; } = [];
}