using FindArt.Core.DataTransferObjects.Product;
using FluentValidation;

namespace FindArt.Api.Validators.Product
{
	public class ProductCreationDtoValidator : AbstractValidator<ProductCreationDto>
	{
		public ProductCreationDtoValidator()
		{
			RuleFor(p => p.Name).NotEmpty();
			RuleFor(p => p.Description).NotEmpty().MaximumLength(1024);
			RuleFor(p => p.OwnerID).NotEmpty();
			RuleFor(p => p.ProductTypeName).NotEmpty();
		}
	}
}
