using FindArt.Core.Interfaces.Repositories.Base;
using FindArt.Core.Interfaces.Services;
using FindArt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Services
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Product>> GetAllProduct()
		{
			return await _unitOfWork.Product.GetAllProductsAsync(trackChanges: false);
		}

		public async Task<Product> GetProduct(string id)
		{
			return await _unitOfWork.Product.GetProductAsync(id, trackChanges: false);
		}

		public void CreateProduct(Product product)
		{
			_unitOfWork.Product.CreateProduct(product);
		}

		public void UpdateProduct(Product product)
		{
			_unitOfWork.Product.UpdateProduct(product);
		}

		public void DeleteProduct(Product product)
		{
			_unitOfWork.Product.DeleteProduct(product);
		}

	}
}
