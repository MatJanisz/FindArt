using FindArt.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
		Task<Product> GetProductAsync(string id, bool trackChanges);
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(Product product);
	}
}
