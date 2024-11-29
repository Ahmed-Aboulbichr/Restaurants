using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder : IRestaurantSeeder
{
    private readonly RestaurantDbContext dbContext;
    public RestaurantSeeder(RestaurantDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = new List<Restaurant>()
        {
            new()
            {
                Name = "KFC",
                Category ="Fast Food",
                Description ="kfc ( short for kentucky fried chiken) is an American fast food restaurant chain...",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10pcs)",
                        Price = 10.30M
                    }
                },
            },
            new Restaurant(){
                Name = "EAES",
                Category ="Fast Food",
                Description ="kfc ( short for kentucky fried chiken) is an American fast food restaurant chain...",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10pcs)",
                        Price = 10.30M
                    }
                },
            },
        };
        return restaurants;
    }
}
