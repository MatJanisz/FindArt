using FindArt.Core.DataTransferObjects.Auction.Base;
using FindArt.Core.DataTransferObjects.Product;

namespace FindArt.Core.DataTransferObjects.Auction
{
	public class AuctionCreationDto : AuctionBaseDto
	{
		public ProductDto Product { get; set; }
	}
}
