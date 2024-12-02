using FluentValidation;
using System.Data;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

internal class UpdateRestaurantDtoValidator : AbstractValidator<UpdateRestaurantCommand>
{
	public UpdateRestaurantDtoValidator()
	{
		RuleFor(dto => dto.Name)
            .Length(3, 100);
        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description is required");

	}
}
