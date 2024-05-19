using Domain.Entity;
using System.Reflection.Metadata;


namespace Application
{
    public interface IBloggingService
    {
        Task<Blogging> AddBlog(Blogging blogs);
        Task<Blogging> UpdateBlog(Blogging blogs);
        Task DeleteBlog(Guid id);
        Task<Blogging> GetBlogById(Guid id);
        Task<IEnumerable<Blogging>> GetAllBlogs();
        Task<IEnumerable<Blogging>> GetAllBlogsPagination(int pageNumber = 1, int pageSize = 10);


    }
}
