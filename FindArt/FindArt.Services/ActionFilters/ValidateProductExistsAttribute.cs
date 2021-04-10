using FindArt.Core.Interfaces.Repositories.Base;
using FindArt.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FindArt.Services.ActionFilters
{
	public class ValidateProductExistsAttribute : IAsyncActionFilter
	{
		private readonly IProductService _productService;
		private readonly ILogger<IProductService> _logger;

		public ValidateProductExistsAttribute(IProductService productService, ILogger<IProductService> logger)
		{
            _productService = productService;
			_logger = logger;
		}

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (string)context.ActionArguments["id"];
            var product = await _productService.GetProduct(id);

            if (product == null)
            {
                _logger.LogInformation($"Company with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("product", product);
                await next();
            }
        }
    }
}
