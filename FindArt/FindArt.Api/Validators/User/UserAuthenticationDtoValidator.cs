using FindArt.Core.DataTransferObjects.User;
using FluentValidation;

namespace FindArt.Api.Validators.User
{
	public class UserAuthenticationDtoValidator : AbstractValidator<UserAuthenticationDto>
	{
		public UserAuthenticationDtoValidator()
		{
			RuleFor(p => p.UserName).NotEmpty();
			RuleFor(p => p.Password).MinimumLength(5);
		}
	}
}
