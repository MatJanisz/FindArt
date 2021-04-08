using AutoMapper;
using FindArt.Core.DataTransferObjects.Auction;
using FindArt.Core.Interfaces.Repositories.Base;
using FindArt.Core.Interfaces.Services;
using FindArt.Core.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Services
{
	public class AuctionService : IAuctionService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly ILogger<IAuctionService> _logger;

		public AuctionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IAuctionService> logger)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IEnumerable<AuctionDto>> GetAllAuctions()
		{
			var products = await _unitOfWork.Auction.GetAllAuctionsAsync(trackChanges: false);
			return _mapper.Map<IEnumerable<AuctionDto>>(products);
		}

		public async Task<AuctionDto> GetAuction(string id)
		{
			var product = await _unitOfWork.Auction.GetAuctionAsync(id, trackChanges: false);
			return _mapper.Map<AuctionDto>(product);
		}

		public async Task AssignProductToAuction(string auctionID, string productID)
		{
			var auction = await _unitOfWork.Auction.GetAuctionAsync(auctionID, trackChanges: true); //check if setting this flag to true cause update
			var product = await _unitOfWork.Product.GetProductAsync(productID, trackChanges: true);
			auction.ProductID = productID;
			product.AuctionID = auctionID;
			await _unitOfWork.SaveAsync();
		}

		public async Task<AuctionDto> CreateAuction(AuctionCreationDto auctionDto)
		{
			var auction = _mapper.Map<Auction>(auctionDto);
			_unitOfWork.Auction.CreateAuction(auction);
			await _unitOfWork.SaveAsync();
			auction = await _unitOfWork.Auction.GetAuctionAsync(auction.AuctionID, false);
			return _mapper.Map<AuctionDto>(auction);
		}

		public async Task UpdateAuction(string id, AuctionUpdateDto auctionDto)
		{
			var auction = _mapper.Map<Auction>(auctionDto);
			var auctionDb = await _unitOfWork.Auction.GetAuctionAsync(id, false);
			auctionDb = _mapper.Map(auctionDb, auction);
			auctionDb.AuctionID = id;
			_unitOfWork.Auction.UpdateAuction(auctionDb);
			await _unitOfWork.SaveAsync();
		}

		public async Task PartiallyUpdateAuction(string id, JsonPatchDocument<AuctionUpdateDto> patchAuctionDto)
		{
			var auctionDb = await _unitOfWork.Auction.GetAuctionAsync(id, false);
			var auctionToPatch = _mapper.Map<AuctionUpdateDto>(auctionDb);
			patchAuctionDto.ApplyTo(auctionToPatch);
			auctionDb = _mapper.Map(auctionToPatch, auctionDb);
			_unitOfWork.Auction.UpdateAuction(auctionDb);
			await _unitOfWork.SaveAsync();
		}

		public async Task DeleteAuction(string id)
		{
			var product = await _unitOfWork.Auction.GetAuctionAsync(id, true);
			_unitOfWork.Auction.DeleteAuction(product);
			await _unitOfWork.SaveAsync();
		}
	}
}
