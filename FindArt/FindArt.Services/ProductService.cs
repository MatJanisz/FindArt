using AutoMapper;
using FindArt.Core.DataTransferObjects.Product;
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
		private readonly IMapper _mapper;

		public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductDto>> GetAllProduct()
		{
			var products = await _unitOfWork.Product.GetAllProductsAsync(trackChanges: false);
			return _mapper.Map<IEnumerable<ProductDto>>(products);
		}

		public async Task<ProductDto> GetProduct(string id)
		{
			var product = await _unitOfWork.Product.GetProductAsync(id, trackChanges: false);
			return _mapper.Map<ProductDto>(product);
		}

		public async Task CreateProduct(ProductDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			_unitOfWork.Product.CreateProduct(product);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateProduct(Product productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			_unitOfWork.Product.UpdateProduct(product);
			await _unitOfWork.SaveAsync();
		}

		public async Task DeleteProduct(Product productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			_unitOfWork.Product.DeleteProduct(product);
			await _unitOfWork.SaveAsync();
		}
	}
}
