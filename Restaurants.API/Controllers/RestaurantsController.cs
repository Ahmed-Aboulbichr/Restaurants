using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Services;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{

    private readonly IRestaurantsService restaurantsService;

    public RestaurantsController(IRestaurantsService restaurantsService)
    {
        this.restaurantsService= restaurantsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAll();
        return Ok(restaurants);
        
    }
}
