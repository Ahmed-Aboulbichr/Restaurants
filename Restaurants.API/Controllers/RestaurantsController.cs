using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Services;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{

    private readonly IRestaurantsService restaurantsService;

    public RestaurantsController(IRestaurantsService restaurantsService)
    {
        this.restaurantsService = restaurantsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAll();
        return Ok(restaurants);

    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var restaurant = await restaurantsService.GetRestaurantById(id);
        if(restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }
}
