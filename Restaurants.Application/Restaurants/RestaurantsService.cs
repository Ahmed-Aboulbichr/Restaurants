using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Restaurants;

public class RestaurantsService : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly ILogger<RestaurantsService> logger;
    private readonly IMapper mapper;

    public RestaurantsService(IRestaurantsRepository restaurantsRepository,
        ILogger<RestaurantsService> logger,
        IMapper mapper)
    {
        _restaurantsRepository = restaurantsRepository;
        this.logger = logger;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAll()
    {
        logger.LogInformation("Getting all restaurants ");
        var restaurants = await _restaurantsRepository.GetAll();

        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants); 
        return restaurantsDto!;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation($"Getting Restaurant with id {id}");
        var restaurant = await _restaurantsRepository.GetRestaurantById(id);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
        return restaurantDto;
    }
}
