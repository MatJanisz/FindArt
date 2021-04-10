using FindArt.Core.DataTransferObjects.Product;
using FindArt.Core.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Services
{
	public interface IProductService
	{
		Task<ProductDto> CreateProduct(ProductCreationDto productDto);
		Task DeleteProduct(ProductDto productDto);
		Task<PagedList<ProductDto>> GetAllProducts(ProductParameters productParameters);
		Task<ProductDto> GetProduct(string id);
		Task UpdateProduct(string id, ProductUpdateDto productDto);
		Task PartiallyUpdateProduct(string id, JsonPatchDocument<ProductUpdateDto> patchProductDto);
	}
}
