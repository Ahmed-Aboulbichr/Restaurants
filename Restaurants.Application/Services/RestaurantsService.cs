using Restaurants.Domain.Entities;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Services;

public class RestaurantsService : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository;

    public RestaurantsService(IRestaurantsRepository restaurantsRepository)
    {
        _restaurantsRepository = restaurantsRepository;
    }

    public async Task<IEnumerable<Restaurant>> GetAll()
    {
        var restaurants = await _restaurantsRepository.GetAll();
        return restaurants;
    }
}
