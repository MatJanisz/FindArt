using FindArt.Core.DataTransferObjects.Auction.Base;
using FindArt.Core.DataTransferObjects.Product;

namespace FindArt.Core.DataTransferObjects.Auction
{
	public class AuctionDto : AuctionBaseDto
	{
		public string AuctionID { get; set; }
		public bool Active { get; set; }
		public ProductDto Product { get; set; }

		//public List<Offer> AuctionOffers { get; set; }
	}
}
