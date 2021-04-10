using AutoMapper;
using FindArt.Core.DataTransferObjects.Auction;
using FindArt.Core.Interfaces.Services;
using FindArt.Core.RequestFeatures;
using FindArt.Services.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindArt.Api.Controllers
{
	[Route("api/auction")]
	[ApiController]
	public class AuctionController : ControllerBase
	{
		private readonly IAuctionService _auctionService;
		private readonly ILogger<AuctionController> _logger;
		private readonly IMapper _mapper;

		public AuctionController(IAuctionService auctionService, ILogger<AuctionController> logger, IMapper mapper)
		{
			_auctionService = auctionService;
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAuctions([FromQuery] AuctionParameters auctionParameters)
		{
			var auctionDtos = await _auctionService.GetAllAuctions(auctionParameters);
			Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(auctionDtos.MetaData));
			return Ok(auctionDtos);
		}

		[HttpGet("{id}", Name = ("GetAuction"))]
		[ServiceFilter(typeof(ValidateAuctionExistsAttribute))]
		public async Task<IActionResult> GetAuction(string id)
		{
			var auction = HttpContext.Items["auction"] as AuctionDto;

			return Ok(auction);
		}

		[HttpPost()]
		public async Task<IActionResult> CreateAuction([FromBody] AuctionCreationDto auctionDto)
		{
			var createdAuction = await _auctionService.CreateAuction(auctionDto);
			return CreatedAtRoute("GetAuction", new { id = createdAuction.AuctionID }, createdAuction);
		}

		[HttpPatch("{id}")]
		[ServiceFilter(typeof(ValidateAuctionExistsAttribute))]
		public async Task<IActionResult> PartiallyUpdate(string id, [FromBody] JsonPatchDocument<AuctionUpdateDto> patchAuctionDto)
		{
			await _auctionService.PartiallyUpdateAuction(id, patchAuctionDto);
			return NoContent();
		}

		[HttpPut("{id}")]
		[ServiceFilter(typeof(ValidateAuctionExistsAttribute))]
		public async Task<IActionResult> AssignProductToAuction(string id, AuctionUpdateDto auctionUpdateDto)
		{
			await _auctionService.AssignProductToAuction(id, auctionUpdateDto.ProductID);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ServiceFilter(typeof(ValidateAuctionExistsAttribute))]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			var auction = HttpContext.Items["auction"] as AuctionDto;
			await _auctionService.DeleteAuction(auction);
			return NoContent();
		}

	}
}
