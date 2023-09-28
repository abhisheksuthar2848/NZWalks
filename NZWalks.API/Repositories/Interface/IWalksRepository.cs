using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.Interface
{
    public interface IWalksRepository
    {
        Task<Walk> CreateAsync(Walk walk);

        Task<List<Walk>> GetAllAsync(string? filterOn=null, string? filterQuery = null
            ,string? sortby = null,bool IsAccending =true,int pageNumber=1,int pageSize=1000);
        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<bool> DeleteAsync(Guid id);
    }
}
