﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NZWalks.API.Controllers
{
	//https://localhost:7073/api/regions

	[Route("api/[controller]")]
	[ApiController]
	public class RegionsController : ControllerBase
	{
		private readonly NZWalksDbContect dbContext;
		private readonly IRegionRepository regionRepository;
		private readonly IMapper mapper;

		public RegionsController(NZWalksDbContect dbContext, IRegionRepository regionRepository, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.regionRepository = regionRepository;
			this.mapper = mapper;
		}
		//GET ALL REGIONS
		//GET//https://localhost:7073/api/regions

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			// Get Data From DataBase - Domain Models
			var regionsDomain = await regionRepository.GetAllAsync();

			//Return mapped DTOs
			return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
		}

		// GET SINGLE REGION BY ID
		//GET//https://localhost:7073/api/regions/{id}
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			//Get Region Domain Model From Database

			var regionDomain = await regionRepository.GetByIdAsync(id);
			if (regionDomain == null)
			{
				return NotFound();
			}


			//Return DTO back to client
			return Ok(mapper.Map<RegionDto>(regionDomain));
		}

		//POST To Create New Region
		//POST:https://localhost:7073/api/regions
		[HttpPost]

		//Check Validations
		[ValidateModel]
		public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
		{
				{
					// Map or Convert DTO to Domain Model
					var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);


					//Use Domain Model to create Region
					regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

					// Map Domain model back to DTO
					var regionDto = mapper.Map<RegionDto>(regionDomainModel);
					return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);
				}
		}

		// Update region
		// PUT:https://localhost:7073/api/regions/{id}
		[HttpPut]
		[Route("{id:Guid}")]

		//Check Validations
		[ValidateModel]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
		{
			//Map DTO to domain model
			var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

			// check if region exists
			regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
			if (regionDomainModel == null)
			{
				return NotFound();
			}

			await dbContext.SaveChangesAsync();

			//Convert domain model to DTO

			return Ok(mapper.Map<RegionDto>(regionDomainModel));
		}

		//DELETE Region
		// DELETE https://localhost:7073/api/regions/{id}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var regionDomainModel = await regionRepository.DeleteAsync(id);

			if (regionDomainModel == null)
			{ return NotFound(); }

			// return deleted Region back
			// map domain model to DTO

			return Ok(mapper.Map<RegionDto>(regionDomainModel));
		}
	}
}
