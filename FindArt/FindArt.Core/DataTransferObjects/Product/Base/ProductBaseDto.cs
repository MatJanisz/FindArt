using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.DataTransferObjects.Product.Base
{
	public abstract class ProductBaseDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ProductTypeName { get; set; }
	}
}
