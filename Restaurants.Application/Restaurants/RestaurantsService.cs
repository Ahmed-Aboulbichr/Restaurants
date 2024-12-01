using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Restaurants;

public class RestaurantsService : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly ILogger<RestaurantsService> logger;

    public RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger)
    {
        _restaurantsRepository = restaurantsRepository;
        this.logger = logger;
    }

    public async Task<IEnumerable<Restaurant>> GetAll()
    {
        logger.LogInformation("Getting all restaurants ");
        var restaurants = await _restaurantsRepository.GetAll();
        return restaurants;
    }

    public async Task<Restaurant?> GetRestaurantById(int id)
    {
        logger.LogInformation($"Getting Restaurant with id {id}");
        var restaurant = await _restaurantsRepository.GetRestaurantById(id);
        return restaurant;
    }
}
