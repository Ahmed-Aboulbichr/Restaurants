using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    private readonly IMediator mediator;

    public RestaurantsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);

    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        if (restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantDto)
    {
        int restaurantId = await mediator.Send(createRestaurantDto);
        return CreatedAtAction(nameof(Get), new { id = restaurantId }, null);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        bool isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
        if (isDeleted)
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand request)
    {
        request.Id = id;
        bool isUpdated = await mediator.Send(request);
        if (isUpdated) return NoContent();
        return NotFound();
    }
}
