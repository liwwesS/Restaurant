namespace Restaurant.Application.Contracts;

public class RestaurantRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}