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
				.ForMember(destination => destination.OwnerEmail, p => p.MapFrom(source => source.Owner.Email))
				.ForMember(dto => dto.ProductTypeName, p => p.MapFrom(x => x.ProductTypeID.ToString()))
				.ReverseMap();

			CreateMap<ProductCreationDto, Product>()
				.ForMember(destination => destination.ProductTypeID, dto => dto.MapFrom(source => ProductType.GetProductTypeValueByName(source.ProductTypeName)));

			CreateMap<ProductUpdateDto, Product>()
				.ForMember(destination => destination.ProductTypeID, dto => dto.MapFrom(source => ProductType.GetProductTypeValueByName(source.ProductTypeName)))
				.ForMember(destination => destination.ID, dto => dto.Ignore())
				.ForMember(destination => destination.AuctionID, dto => dto.Ignore());

			CreateMap<Product, ProductUpdateDto>()
				.ForMember(destination => destination.ProductTypeName, p => p.MapFrom(source => source.ProductType.Name));

			CreateMap<Auction, AuctionDto>();

			CreateMap<AuctionCreationDto, Auction>();

			CreateMap<AuctionUpdateDto, Auction>().ReverseMap();

			CreateMap<UserRegistrationDto, User>();

			CreateMap<UserAuthenticationDto, User>();

		}
	}
}
