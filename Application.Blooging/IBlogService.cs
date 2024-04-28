using Domain.Bloogging.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blooging
{
    public interface IBlogService
    {
        Task<Blog> AddBlog(Blog blog);
        Task<IEnumerable<Blog>> GetBlogList();
        Task<Blog> UpdateBlog(Blog blog);
        Task DeleteStudent(String id);
        Task <Blog> GetBlogById(String id);

    }
}
