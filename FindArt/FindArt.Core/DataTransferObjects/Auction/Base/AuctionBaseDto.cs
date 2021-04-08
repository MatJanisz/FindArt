using FindArt.Core.DataTransferObjects.Product;
using System;

namespace FindArt.Core.DataTransferObjects.Auction.Base
{
	public abstract class AuctionBaseDto
	{
		public decimal InitialPrice { get; set; }
		public DateTime DueDate { get; set; }
		public string ProductID { get; set; }

	}
}
