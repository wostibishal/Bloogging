using Application.Blooging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Blogging
{
    public class BlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<BlogDto>> GetAllBlogsAsync()
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
            return blogs.Select(blog => new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Image = blog.Image,
                DateCreated = blog.DateCreated,
                DateModified = blog.DateModified
            });
        }

        public async Task CreateBlogAsync(BlogDto blogDto)
        {
            var blog = new Blog
            {
                Title = blogDto.Title,
                Content = blogDto.Content,
                Image = blogDto.Image,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            await _blogRepository.CreateBlogAsync(blog);
        }
    }
}
