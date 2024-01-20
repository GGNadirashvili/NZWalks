﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AauthController : ControllerBase
	{
		private readonly UserManager<IdentityUser> userManager;

		public AauthController(UserManager<IdentityUser> userManager)
		{
			this.userManager = userManager;
		}
		// POST: /api/Auth/Register
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
		{

			var identityUser = new IdentityUser
			{
				UserName = registerRequestDto.UserName,
				Email = registerRequestDto.UserName
			};
			var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

			if (identityResult.Succeeded)
			{
				// Add roles to this User
				if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
				{
					identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
					if (identityResult.Succeeded)
					{
						return Ok("User was registered! Please Login.");
					}
				}
			}

			return BadRequest("Something went wrong");
		}

		// POST: /api/Auth/Login
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
		{
			var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
			if (user != null)
			{
			var checkPasswordResult = await	userManager.CheckPasswordAsync(user, loginRequestDto.Password);

				if (checkPasswordResult)
				{
					// Create Token
					return Ok();
				}
			}

			return BadRequest("Username or Password incorrect");
		}
	}
}
