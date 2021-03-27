
namespace FindArt.Core.Models
{
	public class Product
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string OwnerID { get; set; }
		public User Owner { get; set; } //one-to-many
		public ProductTypeID ProductTypeID { get; set; } //nav property
		public ProductType ProductType { get; set; }
		public string AuctionID { get; set; }
		public Auction Auction { get; set; } //one-to-one

	}
}
