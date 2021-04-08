using AutoMapper;
using FindArt.Core.DataTransferObjects.Product;
using FindArt.Core.Interfaces.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindArt.Api.Controllers
{
	[Route("api/product")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly ILogger<ProductController> _logger;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, ILogger<ProductController> logger, IMapper mapper)
		{
			_productService = productService;
			_logger = logger;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			var products = await _productService.GetAllProduct();
			var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
			return Ok(productsDto);
		}

		[HttpGet("{id}", Name = ("GetProduct"))]
		public async Task<IActionResult> GetProduct(string id)
		{
			var products = await _productService.GetProduct(id);
			return Ok(products);
		}

		[HttpPost()]
		public async Task<IActionResult> CreateProduct([FromBody] ProductCreationDto productDto)
		{
			var createdProduct = await _productService.CreateProduct(productDto);
			return CreatedAtRoute("GetProduct", new { id = createdProduct.ID}, createdProduct);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductUpdateDto productDto)
		{
			await _productService.UpdateProduct(id, productDto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _productService.DeleteProduct(id);
			return NoContent();
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> PartiallyUpdate(string id, [FromBody] JsonPatchDocument<ProductUpdateDto> patchProductDto)
		{
			await _productService.PartiallyUpdateProduct(id, patchProductDto);
			return NoContent();
		}

	}
}
