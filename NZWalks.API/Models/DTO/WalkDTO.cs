using NZWalks.API.Models.DTO;

namespace NZWalks.API.Models.Dto
{
	public class WalkDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Length { get; set; }

		public Guid RegionId { get; set; }
		public Guid WalkDifficultyId { get; set; }

		public RegionDto Region { get; set; }
		public DifficultyDto Difficulty { get; set; }
	}
}
