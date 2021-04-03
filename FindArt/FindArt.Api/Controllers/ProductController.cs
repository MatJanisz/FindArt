using AutoMapper;
using FindArt.Core.DataTransferObjects.Product;
using FindArt.Core.Interfaces.Services;
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

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(string id)
		{
			var products = await _productService.GetProduct(id);
			return Ok(products);
		}

		[HttpPost()]
		public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
		{
			await _productService.CreateProduct(productDto);
			return Ok();
		}

		[HttpPut()]
		public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
		{
			await _productService.UpdateProduct(productDto);
			return NoContent();
		}

	}
}
