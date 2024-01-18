using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
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

		public RegionsController(NZWalksDbContect dbContext, IRegionRepository regionRepository)
		{
			this.dbContext = dbContext;
			this.regionRepository = regionRepository;
		}
		//GET ALL REGIONS
		//GET//https://localhost:7073/api/regions

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			// Get Data From DataBase - Domain Models
			var regionsDomain = await regionRepository.GetAllAsync();

			// Map Domain Models to DTOs
			var regionsDto = new List<RegionDto>();
			foreach (var regionDomain in regionsDomain)
			{
				regionsDto.Add(new RegionDto()
				{
					Id = regionDomain.Id,
					Name = regionDomain.Name,
					Code = regionDomain.Code,
					Area = regionDomain.Area,
					Lat = regionDomain.Lat,
					Long = regionDomain.Long,
					Population = regionDomain.Population,
				});
			}

			//Return DTOs

			return Ok(regionsDomain);
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
			// Map/Convert Region Domain Model to Region DTO
			var regionsDto = new RegionDto
			{
				Id = regionDomain.Id,
				Name = regionDomain.Name,
				Code = regionDomain.Code,
				Area = regionDomain.Area,
				Lat = regionDomain.Lat,
				Long = regionDomain.Long,
				Population = regionDomain.Population,
			};

			//Return DTO back to client
			return Ok(regionDomain);
		}

		//POST To Create New Region
		//POST:https://localhost:7073/api/regions
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
		{
			// Map or Convert DTO to Domain Model
			var regionDomainModel = new Region
			{
				Code = addRegionRequestDto.Code,
				Area = addRegionRequestDto.Area,
				Lat = addRegionRequestDto.Lat,
				Long = addRegionRequestDto.Long,
				Population = addRegionRequestDto.Population,
				Name = addRegionRequestDto.Name,
			};

			//Use Domain Model to create Region
			regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
			// Map Domain model back to DTO
			var regionDto = new RegionDto
			{
				Id = regionDomainModel.Id,
				Name = regionDomainModel.Name,
				Code = regionDomainModel.Code,
				Area = regionDomainModel.Area,
				Lat = regionDomainModel.Lat,
				Long = regionDomainModel.Long,
				Population = regionDomainModel.Population,

			};
			return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);
		}

		// Update region
		// PUT:https://localhost:7073/api/regions/{id}
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
		{
			//Map DTO to domain model
			var regionDomainModel = new Region
			{
				Code = updateRegionRequestDto.Code,
				Area = updateRegionRequestDto.Area,
				Lat = updateRegionRequestDto.Lat,
				Long = updateRegionRequestDto.Long,
				Name = updateRegionRequestDto.Name,
				Population = updateRegionRequestDto.Population

			};

			// check if region exists
			regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
			if (regionDomainModel == null)
			{
				return NotFound();
			}

			await dbContext.SaveChangesAsync();

			//Convert domain model to DTO
			var regionDto = new RegionDto
			{
				Id = regionDomainModel.Id,
				Name = regionDomainModel.Name,
				Area = regionDomainModel.Area,
				Population = regionDomainModel.Population,
				Long = regionDomainModel.Long,
				Lat = regionDomainModel.Lat,
			};
			return Ok(regionDto);
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

			var regionDTO = new RegionDto()
			{
				Id = regionDomainModel.Id,
				Name = regionDomainModel.Name,
				Area = regionDomainModel.Area,
				Population = regionDomainModel.Population,
				Long = regionDomainModel.Long,
				Lat = regionDomainModel.Lat,
			};
			return Ok(regionDTO);
		}
	}
}
