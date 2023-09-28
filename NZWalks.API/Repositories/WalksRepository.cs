using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories.Interface;

namespace NZWalks.API.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly NZWalksDbContext dbContext;

        public WalksRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.dbContext = nZWalksDbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var walkDomainModel = await dbContext.Walks.FindAsync(id);
            if (walkDomainModel == null)
            {
                return false;
            }

            dbContext.Walks.Remove(walkDomainModel);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortby = null, bool isAccending = true, int pageNumber=1,int pageSize=1000)
         {

            var Walks = dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .AsQueryable();

            // filtering

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    Walks=Walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortby)==false)
            {
                if (sortby.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    Walks=isAccending ?  Walks.OrderBy(x => x.Name): Walks.OrderByDescending(x=>x.Name);
                }
                else if (sortby.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    Walks = isAccending ? Walks.OrderBy(x => x.LengthInKm) : Walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //Pagination 
            var skipResults = (pageNumber - 1) * pageSize;

            return await Walks.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                 .Include("Difficulty")
                 .Include("Region")
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.LengthInKm = walk.LengthInKm;


            await dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
