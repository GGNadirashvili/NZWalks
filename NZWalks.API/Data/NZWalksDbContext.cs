using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
	public class NZWalksDbContext : DbContext
	{
		public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContectOptions) : base(dbContectOptions)
		{

		}
		public DbSet<Difficulty> Difficulties { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<Walk> Walks { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed data for Difficulties
			//Easy, Medium, Hard

			var difficulties = new List<Difficulty>()
			{
				new Difficulty()
				{
					Id = Guid.Parse("2ad0bbc3-e76d-41ea-9c89-bc9f0198c8fc"),
					Name = "Easy"
				},new Difficulty()
				{
					Id = Guid.Parse("61de3303-15cb-4174-b198-f0fb7b2987be"),
					Name = "Medium"
				},new Difficulty()
				{
					Id = Guid.Parse("8a4e9d73-7cfe-4ca4-a0dd-72ab99293f22"),
					Name = "Hard"
				}
			};

			// Seed difficulties to the database
			modelBuilder.Entity<Difficulty>().HasData(difficulties);


			// Seed data for Regions
			var regions = new List<Region>()
			{
				new Region()
				{
					Id = Guid.Parse("f9d6a5f4-3efa-4bff-84da-201654a2a6a2"),
					Name = "Auckland",
					Code = "Akl"
				},
				new Region()
				{
					Id = Guid.Parse("33eeda0b-2a2d-4be9-ab22-bbe06810f9cc"),
					Name = "Nelson",
					Code = "NSN"
				},new Region()
				{
					Id = Guid.Parse("d3fa0988-920f-4c9a-9143-8f14f3c61e47"),
					Name = "Southland",
					Code = "STL"
				},
			};

			modelBuilder.Entity<Region>().HasData(regions);
		}
	}
}
