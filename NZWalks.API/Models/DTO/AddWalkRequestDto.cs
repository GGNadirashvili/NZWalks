﻿namespace NZWalks.API.Models.DTO
{
	public class AddWalkRequestDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double intengthInKm { get; set; }
		public string? WalkingImageUrl { get; set; }
		public Guid WalkDifficultyId { get; set; }
		public Guid RegionId { get; set; }
	}
}
