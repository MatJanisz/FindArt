using FindArt.Core.DataTransferObjects.Auction;
using FindArt.Core.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Services
{
	public interface IAuctionService
	{
		Task AssignProductToAuction(string auctionID, string productID);
		Task<AuctionDto> CreateAuction(AuctionCreationDto auctionDto);
		Task DeleteAuction(AuctionDto auctionDto);
		Task<PagedList<AuctionDto>> GetAllAuctions(AuctionParameters auctionParameters);
		Task<AuctionDto> GetAuction(string id);
		Task UpdateAuction(string id, AuctionUpdateDto auctionDto);
		Task PartiallyUpdateAuction(string id, JsonPatchDocument<AuctionUpdateDto> patchAuctionDto);
	}
}
