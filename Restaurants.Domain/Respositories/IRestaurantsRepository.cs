using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Respositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetAll();
}
