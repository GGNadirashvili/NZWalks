﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly IImageRepository imageRepository;

		public ImagesController(IImageRepository imageRepository)
		{
			this.imageRepository = imageRepository;
		}
		// Create Action for upload Image
		// POST: /api/images/Upload

		[HttpPost]
		[Route("Upload")]
		public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
		{
			ValidateFileUpload(request);
			if (ModelState.IsValid)
			{
				//convert DTO to Domain model
				var imageDomainModel = new Image
				{
					File = request.File,
					FileExtension = Path.GetExtension(request.File.FileName),
					FileSizeInBytes = request.File.Length,
					FileName = request.FileName,
					FileDescription = request.FileDescription
				};

				// Use repository to upload image
				await imageRepository.Upload(imageDomainModel);
				return Ok(imageDomainModel);
			}

			return BadRequest(ModelState);
		}

		private void ValidateFileUpload(ImageUploadRequestDto request)
		{
			var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };
			if (!allowedExtension.Contains(Path.GetExtension(request.File.FileName)))
			{
				ModelState.AddModelError("file", "Unsupported file extension");
			}

			//if file size is more than 10 MB
			if (request.File.Length > 10485760)
			{
				ModelState.AddModelError("file", "file size is more than 10MB, please upload a smaller size file");
			}
		}
	}
}
