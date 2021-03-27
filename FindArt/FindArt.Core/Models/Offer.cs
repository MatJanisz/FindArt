
namespace FindArt.Core.Models
{
	public class Offer
	{
		public string OfferID { get; set; }
		public string BuyerID { get; set; }
		public User Buyer { get; set; } //one-to-many
		public string AuctionID { get; set; } //one-to-many
		public Auction Auction { get; set; }
		public decimal ProposedPrice { get; set; }
		public decimal BeatenPrice { get; set; }
	}
}
