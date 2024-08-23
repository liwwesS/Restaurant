using Restaurant.Application.Interfaces.Seeders;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Persistence;

namespace Restaurant.Infrastructure.Seeders;

public class RestaurantSeeder(ApplicationDbContext context) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                await context.Restaurants.AddRangeAsync(restaurants);
                await context.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurants> GetRestaurants()
    {
        List<Restaurants> restaurants =
        [
            new Restaurants
            {
                Name = "McDonald's",
                Description = "McDonald's is a global fast-food chain known for its iconic burgers, fries, and shakes. It offers a variety of quick and affordable meals, including the famous Big Mac and Chicken McNuggets.",
                MenuItems =
                [
                    new MenuItem
                    {
                        Name = "Big Mac",
                        Price = 4.89M,
                        Category = "Burgers"
                    },
                    new MenuItem
                    {
                        Name = "Cheeseburger",
                        Price = 1.69M,
                        Category = "Burgers"
                    },
                    new MenuItem
                    {
                        Name = "Quarter Pounder with Cheese",
                        Price = 3.79M,
                        Category = "Burgers"
                    },
                    new MenuItem
                    {
                        Name = "McChicken",
                        Price = 1.29M,
                        Category = "Chicken"
                    },
                    new MenuItem
                    {
                        Name = "Filet-O-Fish",
                        Price = 3.59M,
                        Category = "Fish"
                    },
                    new MenuItem
                    {
                        Name = "Large Fries",
                        Price = 2.49M,
                        Category = "Sides"
                    },
                    new MenuItem
                    {
                        Name = "Medium Soft Drink",
                        Price = 1.00M,
                        Category = "Drinks"
                    },
                    new MenuItem
                    {
                        Name = "Chocolate Shake",
                        Price = 2.19M,
                        Category = "Drinks"
                    },
                    new MenuItem
                    {
                        Name = "Apple Pie",
                        Price = 0.99M,
                        Category = "Desserts"
                    },
                    new MenuItem
                    {
                        Name = "McFlurry",
                        Price = 2.49M,
                        Category = "Desserts"
                    }
                ]
            },
            
            new Restaurants
            {
                Name = "KFC",
                Description = "KFC, or Kentucky Fried Chicken, specializes in fried chicken with a secret blend of 11 herbs and spices. Known for its crispy chicken, KFC also offers sandwiches, sides, and desserts.",
                MenuItems =
                [
                    new MenuItem
                    {
                        Name = "Original Recipe Chicken",
                        Price = 2.99M,
                        Category = "Chicken"
                    },
                    new MenuItem
                    {
                        Name = "Extra Crispy Chicken",
                        Price = 2.99M,
                        Category = "Chicken"
                    },
                    new MenuItem
                    {
                        Name = "Chicken Sandwich",
                        Price = 4.49M,
                        Category = "Sandwiches"
                    },
                    new MenuItem
                    {
                        Name = "Popcorn Nuggets",
                        Price = 3.99M,
                        Category = "Chicken"
                    },
                    new MenuItem
                    {
                        Name = "Mashed Potatoes with Gravy",
                        Price = 2.49M,
                        Category = "Sides"
                    },
                    new MenuItem
                    {
                        Name = "Cole Slaw",
                        Price = 1.99M,
                        Category = "Sides"
                    },
                    new MenuItem
                    {
                        Name = "Biscuit",
                        Price = 0.99M,
                        Category = "Sides"
                    },
                    new MenuItem
                    {
                        Name = "Pepsi",
                        Price = 1.79M,
                        Category = "Drinks"
                    },
                    new MenuItem
                    {
                        Name = "Chocolate Chip Cookie",
                        Price = 0.99M,
                        Category = "Desserts"
                    }
                ]
            },
            
            new Restaurants
            {
                Name = "Burger King",
                Description = "Burger King is a popular fast-food chain famous for its flame-grilled burgers, especially the Whopper. It provides a range of sandwiches, sides, and beverages, catering to all tastes.",
                MenuItems =
                [
                    new MenuItem
                    {
                        Name = "Whopper",
                        Price = 4.19M,
                        Category = "Burgers"
                    },
                    new MenuItem
                    {
                        Name = "Bacon King",
                        Price = 5.99M,
                        Category = "Burgers"
                    },
                    new MenuItem
                    {
                        Name = "Chicken Fries",
                        Price = 3.69M,
                        Category = "Chicken"
                    },
                    new MenuItem
                    {
                        Name = "Original Chicken Sandwich",
                        Price = 4.49M,
                        Category = "Sandwiches"
                    },
                    new MenuItem
                    {
                        Name = "French Fries",
                        Price = 2.29M,
                        Category = "Sides"
                    },
                    new MenuItem
                    {
                        Name = "Onion Rings",
                        Price = 2.39M,
                        Category = "Sides"
                    },
                    new MenuItem
                    {
                        Name = "Soft Drink",
                        Price = 1.99M,
                        Category = "Drinks"
                    },
                    new MenuItem
                    {
                        Name = "Hershey's Sundae Pie",
                        Price = 2.19M,
                        Category = "Desserts"
                    },
                    new MenuItem
                    {
                        Name = "Chocolate Shake",
                        Price = 2.99M,
                        Category = "Drinks"
                    }
                ]
            }
        ];

        return restaurants;
    }
}
