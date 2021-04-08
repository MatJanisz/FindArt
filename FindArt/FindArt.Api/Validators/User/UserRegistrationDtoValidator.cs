using FindArt.Core.DataTransferObjects.User;
using FluentValidation;

namespace FindArt.Api.Validators.User
{
	public class UserRegistrationDtoValidator : AbstractValidator<UserRegistrationDto>
	{
		public UserRegistrationDtoValidator()
		{
			RuleFor(p => p.UserName).NotEmpty();
			RuleFor(p => p.Password).MinimumLength(5);
			RuleFor(p => p.FirstName).NotEmpty();
			RuleFor(p => p.LastName).NotEmpty();
			RuleFor(p => p.Email).EmailAddress();
			RuleFor(p => p.PhoneNumber).NotEmpty();
		}
	}
}
