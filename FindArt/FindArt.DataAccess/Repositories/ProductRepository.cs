using FindArt.Core.Interfaces.Repositories;
using FindArt.Core.Models;
using FindArt.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindArt.DataAccess
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(FindArtDbContext repositoryContext) : base(repositoryContext)
		{
		}

		public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
			await FindAll(trackChanges)
			.OrderBy(p => p.Name)
			.ToListAsync();

		public async Task<Product> GetProductAsync(string id, bool trackChanges) =>
			await FindByCondition(p => p.ID.Equals(id), trackChanges)
			.SingleOrDefaultAsync();

		public void CreateProduct(Product product) => Create(product);

		public void DeleteProduct(Product product) => Delete(product);

		public void UpdateProduct(Product product) => Update(product);
	}
}
