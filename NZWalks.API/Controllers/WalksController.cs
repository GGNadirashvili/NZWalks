﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
	// api/walks
	[Route("api/[controller]")]
	[ApiController]
	public class WalksController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IWalkRepository walkRepository;

		public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
			this.mapper = mapper;
			this.walkRepository = walkRepository;
		}
        // CREATE walk
        // POST: /api/walks
        [HttpPost]
		public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalRequestDto)
		{
			// Map DTO to Domain Model
			var walkDomainModel = mapper.Map<Walk>(addWalRequestDto);

			await walkRepository.CreateAsync(walkDomainModel);

			// Map Domain Model to DTO

			return Ok(mapper.Map<WalkDto>(walkDomainModel));

		}

		//GET Walks
		//GET: /api/walks
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var walksDomainModel = await walkRepository.GetAllAsync();
			
			//Map Domain Model to DTO
			return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
		}
	}
}
