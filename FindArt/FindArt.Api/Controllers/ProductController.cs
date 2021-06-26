using AutoMapper;
using FindArt.Core.DataTransferObjects.Product;
using FindArt.Core.Interfaces.Services;
using FindArt.Core.RequestFeatures;
using FindArt.Services.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Api.Controllers
{
	[Route("api/product")]
	[ApiController]
	[ResponseCache(CacheProfileName = "120SecondsDuration")]
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
		[ResponseCache(Duration = 60)] //adds cache-control header - 60s. It has higher priority than controller's cache
		public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
		{
			var productsDto = await _productService.GetAllProducts(productParameters);
			Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(productsDto.MetaData));
			return Ok(productsDto);
		}

		[HttpGet("{id}", Name = ("GetProduct"))]
		[ServiceFilter(typeof(ValidateProductExistsAttribute))]
		public IActionResult GetProduct(string id)
		{
			var product = HttpContext.Items["product"] as ProductDto;

			return Ok(product);
		}

		[HttpPost()]
		public async Task<IActionResult> CreateProduct([FromBody] ProductCreationDto productDto)
		{
			var createdProduct = await _productService.CreateProduct(productDto);
			return CreatedAtRoute("GetProduct", new { id = createdProduct.ID}, createdProduct);
		}

		[HttpPut("{id}")]
		[ServiceFilter(typeof(ValidateProductExistsAttribute))]
		public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductUpdateDto productUpdateDto)
		{
			await _productService.UpdateProduct(id, productUpdateDto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ServiceFilter(typeof(ValidateProductExistsAttribute))]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			var product = HttpContext.Items["product"] as ProductDto;
			await _productService.DeleteProduct(product);
			return NoContent();
		}

		[HttpPatch("{id}")]
		[ServiceFilter(typeof(ValidateProductExistsAttribute))]
		public async Task<IActionResult> PartiallyUpdate(string id, [FromBody] JsonPatchDocument<ProductUpdateDto> patchProductDto)
		{
			await _productService.PartiallyUpdateProduct(id, patchProductDto);
			return NoContent();
		}

	}
}
