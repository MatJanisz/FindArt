using AutoMapper;
using FindArt.Core.DataTransferObjects.Auction;
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
		public async Task<IActionResult> GetAuctions()
		{
			var auctions = await _auctionService.GetAllAuctions();
			var auctionsDto = _mapper.Map<IEnumerable<AuctionDto>>(auctions);
			return Ok(auctionsDto);
		}

		[HttpGet("{id}", Name = ("GetAuction"))]
		public async Task<IActionResult> GetAuction(string id)
		{
			var auctions = await _auctionService.GetAuction(id);
			return Ok(auctions);
		}

		[HttpPost()]
		public async Task<IActionResult> CreateAuction([FromBody] AuctionCreationDto auctionDto)
		{
			var createdAuction = await _auctionService.CreateAuction(auctionDto);
			return CreatedAtRoute("GetAuction", new { id = createdAuction.AuctionID }, createdAuction);
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> PartiallyUpdate(string id, [FromBody] JsonPatchDocument<AuctionUpdateDto> patchAuctionDto)
		{
			await _auctionService.PartiallyUpdateAuction(id, patchAuctionDto);
			return NoContent();
		}

		[HttpPut("{auctionId}")]
		public async Task<IActionResult> AssignProductToAuction(string auctionId, AuctionUpdateDto auctionUpdateDto)
		{
			await _auctionService.AssignProductToAuction(auctionId, auctionUpdateDto.ProductID);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _auctionService.DeleteAuction(id);
			return NoContent();
		}

	}
}
