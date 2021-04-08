using FindArt.Core.DataTransferObjects.Product.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.DataTransferObjects.Product
{
	public class ProductUpdateDto : ProductBaseDto
	{
		public string OwnerID { get; set; }
	}
}
