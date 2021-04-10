using FindArt.Core.Models;
using FindArt.Core.RequestFeatures;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Repositories
{
	public interface IProductRepository
	{
		Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
		Task<Product> GetProductAsync(string id, bool trackChanges);
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(Product product);
	}
}
