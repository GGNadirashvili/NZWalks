using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContect : DbContext
	{
		public NZWalksDbContect(DbContextOptions dbContectOptions) : base(dbContectOptions)
		{

		}
		public DbSet<WalkDifficulty> Difficulties { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<Walk> Walks { get; set; }
	}
}
