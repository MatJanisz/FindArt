using FindArt.Core.Interfaces.Repositories.Base;
using FindArt.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FindArt.Services.ActionFilters
{
	public class ValidateAuctionExistsAttribute : IAsyncActionFilter
	{
		private readonly IAuctionService _auctionService;
		private readonly ILogger<IAuctionService> _logger;

		public ValidateAuctionExistsAttribute(IAuctionService auctionService, ILogger<IAuctionService> logger)
		{
            _auctionService = auctionService;
			_logger = logger;
		}

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (string)context.ActionArguments["id"];
            var auction = await _auctionService.GetAuction(id);

            if (auction == null)
            {
                _logger.LogInformation($"Auction with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("auction", auction);
                await next();
            }
        }
    }
}
