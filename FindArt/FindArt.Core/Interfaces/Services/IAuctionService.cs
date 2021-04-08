using FindArt.Core.DataTransferObjects.Auction;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Services
{
	public interface IAuctionService
	{
		Task AssignProductToAuction(string auctionID, string productID);
		Task<AuctionDto> CreateAuction(AuctionCreationDto auctionDto);
		Task DeleteAuction(string id);
		Task<IEnumerable<AuctionDto>> GetAllAuctions();
		Task<AuctionDto> GetAuction(string id);
		Task UpdateAuction(string id, AuctionUpdateDto auctionDto);
		Task PartiallyUpdateAuction(string id, JsonPatchDocument<AuctionUpdateDto> patchAuctionDto);
	}
}
