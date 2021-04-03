using FindArt.Core.DataTransferObjects.Product;
using FindArt.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Services
{
	public interface IProductService
	{
		Task CreateProduct(ProductDto productDto);
		Task DeleteProduct(Product productDto);
		Task<IEnumerable<ProductDto>> GetAllProduct();
		Task<ProductDto> GetProduct(string id);
		Task UpdateProduct(ProductDto productDto);
	}
}
