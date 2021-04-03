using AutoMapper;
using FindArt.Core.DataTransferObjects.Auction;
using FindArt.Core.DataTransferObjects.Product;
using FindArt.Core.DataTransferObjects.User;
using FindArt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductDto>()
				.ForMember(dto => dto.OwnerEmail, p => p.MapFrom(x => x.Owner.Email))
				.ForMember(dto => dto.ProductType, p => p.MapFrom(x => x.ProductTypeID.ToString()));

			CreateMap<ProductDto, Product>()
				.ForMember(p => p.ProductType, dto => dto.MapFrom(x => new ProductType(x.ProductType)));

			CreateMap<Auction, AuctionDto>().ReverseMap();

			CreateMap<UserRegistrationDto, User>();

			CreateMap<UserAuthenticationDto, User>();

		}
	}
}
