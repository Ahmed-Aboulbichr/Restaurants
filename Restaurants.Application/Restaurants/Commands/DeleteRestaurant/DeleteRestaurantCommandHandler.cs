using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand>
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
    public async Task<Unit> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Deleting  restaurant {restaurantId}", request.id);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.id) ??
            throw new NotFoundException(nameof(Restaurant), request.id.ToString());
        await restaurantsRepository.Delete(restaurant);
        return Unit.Value;
    }
}
