using System;

namespace FindArt.Core.Models
{
	public class Auction
	{
		public string AuctionID { get; set; }
		public decimal InitialPrice { get; set; }
		public DateTime DueDate { get; set; }
		public bool Active { get; set; }
		public string ProductID { get; set; }
		public Product Product { get; set; } //one to one
	}
}
