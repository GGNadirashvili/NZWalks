using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
	public class AddWalkRequestDto
	{
	

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1000)]
		public string Description { get; set; }

		[Required]

		public double LentengthInKm { get; set; }

		[Required]

		public string? WalkingImageUrl { get; set; }

		[Required]

		public Guid WalkDifficultyId { get; set; }

		[Required]

		public Guid RegionId { get; set; }
	}
}
