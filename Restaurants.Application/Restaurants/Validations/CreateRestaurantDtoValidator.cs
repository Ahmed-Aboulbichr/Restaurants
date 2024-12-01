using FluentValidation;
using FluentValidation.Results;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validations;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
	private readonly List<string> validCategories = new(){ "Italian", "Mexican", "Japanese", "American", "Indian" };
	public CreateRestaurantDtoValidator()
	{
		RuleFor(dto => dto.Name)
			.Length(3, 100);
		RuleFor(dto => dto.Description)
			.NotEmpty()
			.WithMessage("Description is required");
		RuleFor(dto => dto.Category)
			.Must(validCategories.Contains)
			.WithMessage("Invalid Category. Please choose from the valid categories");
			/*.Custom((value, context) =>
			{
				var isValid = validCategories.Contains(value);
				if (!isValid)
				{
					context.AddFailure("Category", "Please choose a valid category");
				}
			});*/
		RuleFor(dto => dto.ContactEmail)
			.EmailAddress()
			.WithMessage("Please provide a valid email address");
		RuleFor(dto => dto.PostalCode)
			.Matches(@"^\d{2}-d{3}$")
			.WithMessage("Please provide a valid postal code XX-XXX");

	}
}
