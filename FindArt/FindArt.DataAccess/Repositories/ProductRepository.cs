using FindArt.Core.Interfaces.Repositories;
using FindArt.Core.Models;
using FindArt.Core.RequestFeatures;
using FindArt.DataAccess.Repositories.Base;
using FindArt.DataAccess.Repositories.Extensions;
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

		public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
		{
			var products = await FindByCondition(p => p.ProductType.Name == productParameters.ProductTypeName, trackChanges)
			.Include(p => p.Owner)
			.Sort(productParameters.OrderBy)
			.ToListAsync();

			return PagedList<Product>
				.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
		}


		public async Task<Product> GetProductAsync(string id, bool trackChanges) =>
			await FindByCondition(p => p.ID.Equals(id), trackChanges)
			.Include(p => p.Owner)
			.Include(p => p.ProductType)
			.SingleOrDefaultAsync();

		public void CreateProduct(Product product) => Create(product);

		public void DeleteProduct(Product product) => Delete(product);

		public void UpdateProduct(Product product) => Update(product);
	}
}
