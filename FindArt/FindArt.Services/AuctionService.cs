using AutoMapper;
using FindArt.Core.DataTransferObjects.Auction;
using FindArt.Core.Interfaces.Repositories.Base;
using FindArt.Core.Interfaces.Services;
using FindArt.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Services
{
	public class AuctionService : IAuctionService, IAuctionService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public AuctionService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<AuctionDto>> GetAllProduct()
		{
			var products = await _unitOfWork.Product.GetAllProductsAsync(trackChanges: false);
			return _mapper.Map<IEnumerable<AuctionDto>>(products);
		}

		public async Task<AuctionDto> GetProduct(string id)
		{
			var product = await _unitOfWork.Product.GetProductAsync(id, trackChanges: false);
			return _mapper.Map<AuctionDto>(product);
		}

		public async Task AssignProductToAuction(string auctionID, string productID)
		{
			var auction = await _unitOfWork.Auction.GetAuctionAsync(auctionID, trackChanges: true); //check if setting this flag to true cause update
			auction.ProductID = productID;
			await _unitOfWork.SaveAsync();
		}

		public async Task CreateAuction(AuctionDto auctionDto)
		{
			var auction = _mapper.Map<Auction>(auctionDto);
			_unitOfWork.Auction.CreateAuction(auction);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateAuction(AuctionDto auctionDto)
		{
			var auction = _mapper.Map<Auction>(auctionDto);
			_unitOfWork.Auction.UpdateAuction(auction);
			await _unitOfWork.SaveAsync();
		}

		public async Task DeleteAuction(AuctionDto auctionDto)
		{
			var auction = _mapper.Map<Product>(auctionDto);
			_unitOfWork.Product.DeleteProduct(auction);
			await _unitOfWork.SaveAsync();
		}
	}
}
