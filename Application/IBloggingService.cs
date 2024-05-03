using Domain;


namespace Application
{
    public interface IBloggingService
    {
        Task<Blogging> AddBlogging(Blogging blogging);
        Task<Blogging> UpdateBlogging(Blogging blogging);
        Task<bool> DeleteBlogging(Guid BlogId);
        Task<Blogging> GetBloggingById(Guid BlogId);
        Task<IEnumerable<Blogging>> GetAllBloggings();
        Task<IEnumerable<Reaction>> GetReactionByBlog(Guid BlogId);
        

    }
}
