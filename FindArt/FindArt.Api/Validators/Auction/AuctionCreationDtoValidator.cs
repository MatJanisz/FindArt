using FindArt.Core.DataTransferObjects.Auction;
using FluentValidation;
using System;

namespace FindArt.Api.Validators.Auction
{
	public class AuctionCreationDtoValidator : AbstractValidator<AuctionCreationDto>
	{
		public AuctionCreationDtoValidator()
		{
			RuleFor(p => p.InitialPrice).GreaterThan(0);
			RuleFor(p => p.DueDate).Must(date => date > DateTime.Now).WithMessage("{PropertyName} can not be earlier than current DateTime"); ;
		}
	}
}
