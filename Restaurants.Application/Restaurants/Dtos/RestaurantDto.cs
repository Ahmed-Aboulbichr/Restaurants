using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantDto
{

    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }

    public string? ContactNumber { get; set; }
    public string? ContactEmail { get; set; }

    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public List<DishDto> Dishes { get; set; } = new();

    public static RestaurantDto? FromEntity(Restaurant? restaurant)
    {
        if (restaurant is null) return null;
        return new RestaurantDto()
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Category = restaurant.Category,
            HasDelivery = restaurant.HasDelivery,
            ContactNumber = restaurant.ContactNumber,
            ContactEmail = restaurant.ContactEmail,
            City = restaurant.Address is null ? "" : restaurant.Address.City,
            Street = restaurant.Address is null ? "" : restaurant.Address.Street,
            PostalCode = restaurant.Address is null ? "" : restaurant.Address.PostalCode,
            Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList(),
        };
    }
}
