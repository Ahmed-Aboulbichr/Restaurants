﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<int> Create(Restaurant restaurant)
    {
        await restaurantDbContext.AddAsync(restaurant);
        await restaurantDbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task Delete(Restaurant restaurant)
    {
        restaurantDbContext.Remove(restaurant);
        await restaurantDbContext.SaveChangesAsync();

    }

    public  async Task<IEnumerable<Restaurant>> GetAll()
    {
        var restaurants = await restaurantDbContext.Restaurants
            .Include(r => r.Dishes)
            .ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetRestaurantById(int id)
    {
        var restaurant = await restaurantDbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(x => x.Id == id);
        return restaurant;
    }

    public async Task SaveChanges()
    {
        await restaurantDbContext.SaveChangesAsync();
    }
}
