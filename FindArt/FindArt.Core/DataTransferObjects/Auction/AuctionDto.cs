using FindArt.Core.DataTransferObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.DataTransferObjects.Auction
{
	public class AuctionDto
	{
		public string AuctionID { get; set; }
		public decimal InitialPrice { get; set; }
		public DateTime DueDate { get; set; }
		public bool Active { get; set; }
		public string ProductID { get; set; }
		public ProductDto Product { get; set; }
		//public List<Offer> AuctionOffers { get; set; }
	}
}
