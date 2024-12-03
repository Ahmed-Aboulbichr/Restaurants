using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    private readonly IRestaurantsRepository restaurantsRepository;
    private readonly ILogger<GetRestaurantByIdQueryHandler> logger;
    private readonly IMapper mapper;

    public GetRestaurantByIdQueryHandler(IRestaurantsRepository restaurantsRepository,
        ILogger<GetRestaurantByIdQueryHandler> logger,
        IMapper mapper)
    {
        this.restaurantsRepository = restaurantsRepository;
        this.logger = logger;
        this.mapper = mapper;
    }
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting Restaurant with id {requestId} ", request.id);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.id) ??
            throw new NotFoundException("Restaurant" , request.id.ToString());
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto!;
    }
}
