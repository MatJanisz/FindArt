using System.Collections.Generic;

namespace FindArt.Core.Models
{
	public enum ProductTypeID : int
	{
		Painting = 0,
		Drawing = 1,
		Graphics = 2,
		Calligraphy = 3,
		Fotography = 4,
		Architecture = 5,
		Sculpture = 6,
		Ceramics = 7
	}

	public class ProductType
	{
		public ProductTypeID ProductTypeID { get; set; }
		public string Name { get; set; }
		public List<Product> Products { get; set; }
	}
}
