using FindArt.Core.DataTransferObjects.Auction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Services
{
	public interface IAuctionService
	{
		Task AssignProductToAuction(string auctionID, string productID);
		Task CreateAuction(AuctionDto auctionDto);
		Task DeleteAuction(AuctionDto auctionDto);
		Task<IEnumerable<AuctionDto>> GetAllProduct();
		Task<AuctionDto> GetProduct(string id);
		Task UpdateAuction(AuctionDto auctionDto);
	}
}
