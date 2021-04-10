using AutoMapper;
using FindArt.Core.DataTransferObjects.Product;
using FindArt.Core.Interfaces.Repositories.Base;
using FindArt.Core.Interfaces.Services;
using FindArt.Core.Models;
using FindArt.Core.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
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
		private readonly ILogger<IProductService> _logger;


		public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IProductService> logger)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<PagedList<ProductDto>> GetAllProducts(ProductParameters productParameters)
		{
			var products = await _unitOfWork.Product.GetAllProductsAsync(productParameters, trackChanges: false);
			var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products).ToList();
			return new PagedList<ProductDto>(productDtos, products.MetaData);
		}

		public async Task<ProductDto> GetProduct(string id)
		{
			var product = await _unitOfWork.Product.GetProductAsync(id, trackChanges: false);
			return _mapper.Map<ProductDto>(product);
		}

		public async Task<ProductDto> CreateProduct(ProductCreationDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			_unitOfWork.Product.CreateProduct(product);
			await _unitOfWork.SaveAsync();
			product = await _unitOfWork.Product.GetProductAsync(product.ID, false);
			return _mapper.Map<ProductDto>(product);
		}

		public async Task UpdateProduct(string id, ProductUpdateDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			var productDb = await _unitOfWork.Product.GetProductAsync(id, false);
			product.ID = id;
			product.AuctionID = productDb.AuctionID;
			_unitOfWork.Product.UpdateProduct(product);
			await _unitOfWork.SaveAsync();
		}

		public async Task PartiallyUpdateProduct(string id, JsonPatchDocument<ProductUpdateDto> patchProductDto)
		{
			var productDb = await _unitOfWork.Product.GetProductAsync(id, false);
			var productToPatch = _mapper.Map<ProductUpdateDto>(productDb);
			patchProductDto.ApplyTo(productToPatch);
			productDb = _mapper.Map(productToPatch, productDb);
			_unitOfWork.Product.UpdateProduct(productDb);
			await _unitOfWork.SaveAsync();
		}

		public async Task DeleteProduct(ProductDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			_unitOfWork.Product.DeleteProduct(product);
			await _unitOfWork.SaveAsync();
		}
	}
}
