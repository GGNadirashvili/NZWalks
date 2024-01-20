using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
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

		//Check Validations
		[ValidateModel]
		public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalRequestDto)
		{

			// Map DTO to Domain Model
			var walkDomainModel = mapper.Map<Walk>(addWalRequestDto);

			await walkRepository.CreateAsync(walkDomainModel);

			// Map Domain Model to DTO

			return Ok(mapper.Map<WalkDto>(walkDomainModel));

		}


		//GET Walks
		//GET: /api/walks?filterOn=Name&filterQuery=Track
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery )
		{
			var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery);

			//Map Domain Model to DTO
			return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
		}

		// GET Walks by Id
		// Get /api/walks/{id}

		[HttpGet]
		[Route("{id:Guid}")]

		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			var walkDomainModel = await walkRepository.GetByIdAsync(id);
			if (walkDomainModel == null)
			{
				return NotFound();
			}
			// Map Domain Model to DTO
			return Ok(mapper.Map<WalkDto>(walkDomainModel));
		}


		//UPDATE Walt by Id
		// PUT /api/walks/{id}

		[HttpPut]
		[Route("{id:Guid}")]



		//Check Validations
		[ValidateModel]
		public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalksRequestDto updateWalksRequestDto)
		{

			// MAP DTO to Domain Model
			var walkDomainModel = mapper.Map<Walk>(updateWalksRequestDto);

			walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
			if (walkDomainModel == null)
			{
				return NotFound();
			}

			//MAP Domain Model to DTO
			return Ok(mapper.Map<WalkDto>(walkDomainModel));
		}


		//DELETE a Walk by Id
		// DELETE: /api/walks/{id}

		[HttpDelete]
		[Route("{id:Guid}")]

		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

			if (deletedWalkDomainModel == null)
			{
				return NotFound();
			}

			//Map Domain Model to DTO

			return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
		}
	}
}
