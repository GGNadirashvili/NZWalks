namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double intengthInKm { get; set; }
        public string? WalkingImageUrl { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // Navigation Properties
        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }

    }
}


