using FindArt.Core.DataTransferObjects.Product.Base;
using FindArt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.DataTransferObjects.Product
{
	public class ProductDto : ProductBaseDto
	{
		public string ID { get; set; }
		public string OwnerEmail { get; set; }
	}
}
