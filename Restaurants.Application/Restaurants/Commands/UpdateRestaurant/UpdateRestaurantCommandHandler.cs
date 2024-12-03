using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand>
{

    private readonly IRestaurantsRepository restaurantsRepository;
    private readonly ILogger<UpdateRestaurantCommandHandler> logger;
    private readonly IMapper mapper;
    public UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
        ILogger<UpdateRestaurantCommandHandler> logger,
        IMapper mapper)
    {
        this.restaurantsRepository = restaurantsRepository;
        this.logger = logger;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating  restaurant {restaurantId} : {@UpdatedRestaurant}", request.Id, request);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.Id) ??
            throw new NotFoundException($"Restaurant", request.Id.ToString());

        mapper.Map(request, restaurant);

        await restaurantsRepository.SaveChanges();
        return Unit.Value;
    }
}
