using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

	}
}
