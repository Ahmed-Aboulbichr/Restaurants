using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
{
    private readonly IRestaurantsRepository restaurantsRepository;
    private readonly ILogger<CreateRestaurantCommandHandler> logger;
    private readonly IMapper mapper;

    public CreateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
        ILogger<CreateRestaurantCommandHandler> logger,
        IMapper mapper)
    {
        this.restaurantsRepository = restaurantsRepository;
        this.logger = logger;
        this.mapper = mapper;
    }


    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Creating new restaurant {request.Name}");
        var restaurant = mapper.Map<Restaurant>(request);
        int restaurantId = await restaurantsRepository.Create(restaurant);
        return restaurantId;
    }
}
