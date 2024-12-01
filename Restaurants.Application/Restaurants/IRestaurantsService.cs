using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants;

public interface IRestaurantsService
{
    Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto);
    Task<IEnumerable<RestaurantDto>> GetAll();
    Task<RestaurantDto?> GetRestaurantById(int id);
}