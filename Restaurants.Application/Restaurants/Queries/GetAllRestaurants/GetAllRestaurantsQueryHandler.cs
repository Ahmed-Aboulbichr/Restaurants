﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Respositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    private readonly IRestaurantsRepository restaurantsRepository;
    private readonly ILogger<GetAllRestaurantsQueryHandler> logger;
    private readonly IMapper mapper;

    public GetAllRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository,
        ILogger<GetAllRestaurantsQueryHandler> logger,
        IMapper mapper)
    {
        this.restaurantsRepository = restaurantsRepository;
        this.logger = logger;
        this.mapper = mapper;
    }
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants ");
        var restaurants = await restaurantsRepository.GetAll();

        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDto!;
    }
}
