using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, bool>
{
    private readonly IRestaurantsRepository restaurantsRepository;
    private readonly ILogger<DeleteRestaurantCommandHandler> logger;
    private readonly IMapper mapper;

    public DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
        ILogger<DeleteRestaurantCommandHandler> logger,
        IMapper mapper)
    {
        this.restaurantsRepository = restaurantsRepository;
        this.logger = logger;
        this.mapper = mapper;
    }
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation($"Deleting  restaurant {request.id}");
        var restaurant = await restaurantsRepository.GetRestaurantById(request.id);
        if (restaurant == null) return false;
        await restaurantsRepository.Delete(restaurant);
        return true;
    }
}
