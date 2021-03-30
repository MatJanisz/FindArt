using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindArt.Api.Controllers
{
	[Route("api/test")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet]
		public IActionResult Test()
		{
			return Ok();
		}

		[HttpGet("testAuthorize"), Authorize]
		public IActionResult TestAuthorize()
		{
			return Ok();
		}
	}
}
