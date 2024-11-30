using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Respositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;
internal class RestaurantsRepository : IRestaurantsRepository
{
    private readonly RestaurantDbContext restaurantDbContext;

    public RestaurantsRepository(RestaurantDbContext restaurantDbContext)
    {
        this.restaurantDbContext = restaurantDbContext;
    }

    public  async Task<IEnumerable<Restaurant>> GetAll()
    {
        var restaurants = await restaurantDbContext.Restaurants.ToListAsync();
        return restaurants;
    }
}
