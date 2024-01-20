﻿using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
	public class SQLWalkRepository : IWalkRepository
	{
		private readonly NZWalksDbContect dbContext;

		public SQLWalkRepository(NZWalksDbContect dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<Walk> CreateAsync(Walk walk)
		{
			await dbContext.Walks.AddAsync(walk);
			await dbContext.SaveChangesAsync();
			return walk;
		}

		async public Task<Walk?> DeleteAsync(Guid id)
		{
			var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
			if (existingWalk != null)
			{
				return null;
			}

			dbContext.Walks.Remove(existingWalk);
			await dbContext.SaveChangesAsync();
			return existingWalk;
		}

		public async Task<List<Walk>> GetAllAsync()
		{
			return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
		}

		public async Task<Walk?> GetById(Guid id)
		{
			return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);

		}

		public Task<Walk?> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		async public Task<Walk?> UpdateAsync(Guid id, Walk walk)
		{
			var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
			if (existingWalk == null)
			{
				return null;
			}

			existingWalk.Name = walk.Name;
			existingWalk.Description = walk.Description;
			existingWalk.RegionId = walk.RegionId;
			existingWalk.DifficultyId = walk.DifficultyId;
			existingWalk.WalkImageUrl = walk.WalkImageUrl;
			existingWalk.LengthInKm = walk.LengthInKm;

			await dbContext.SaveChangesAsync();

			return existingWalk;

		}
	}
}
