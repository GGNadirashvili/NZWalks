using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
	public class NZWalksAuthDbContext : IdentityDbContext
	{
		public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var readerId = "9d4e87fa-aca9-497b-8326-7f6c1503ab99";
			var writerRoleId = "a4e37dcc-db95-4bf3-903c-d2436ff31d8a";
			var roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Id = readerId,
					ConcurrencyStamp = readerId,
					Name = "Reader",
					NormalizedName = "Reader".ToUpper()
				},
					new IdentityRole
				{
					Id = writerRoleId,
					ConcurrencyStamp = writerRoleId,
					Name = "Writer",
					NormalizedName = "Writer".ToUpper()
				}
			};

			builder.Entity<IdentityRole>().HasData(roles);
		}
	}
}
