using FindArt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.DataTransferObjects
{
	public class ProductDto
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string OwnerEmail { get; set; }
		public ProductTypeID ProductTypeID { get; set; }
		public string AuctionID { get; set; }
	}
}
