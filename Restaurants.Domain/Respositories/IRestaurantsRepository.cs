using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Respositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetAll();
    Task<Restaurant?> GetRestaurantById(int id);
}
