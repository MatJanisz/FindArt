using AutoMapper;
using FindArt.Core.DataTransferObjects.User;
using FindArt.Core.Interfaces.Services;
using FindArt.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindArt.Api.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly IAuthenticationService _authenticationService;
		private readonly ILogger<AuthenticationController> _logger;
        private readonly IMapper _mapper;


        public AuthenticationController(UserManager<User> userManager, IAuthenticationService authenticationService, ILogger<AuthenticationController> logger, IMapper mapper)
		{
			_userManager = userManager;
			_authenticationService = authenticationService;
			_logger = logger;
            _mapper = mapper;
		}

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDto user)
        {
            if (!await _authenticationService.ValidateUser(user))
            {
                _logger.LogWarning($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await _authenticationService.CreateToken() });
        }

    }
}
