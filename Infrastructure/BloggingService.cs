using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BloggingService : IBloggingService
    {
        private readonly ApplicationDBContext _dbContext;

        public BloggingService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Blogging> AddBlogging(Blogging blogging)
        {
            var result = await _dbContext.Blogs.AddAsync(blogging);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteBlogging(Guid BlogId)
        {
            var blog = await _dbContext.Blogs.FindAsync(BlogId);
            if (blog == null)
            {
                return false;
            }
            _dbContext.Blogs.Remove(blog);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Blogging>> GetAllBloggings()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blogging> GetBloggingById(Guid BlogId)
        {
            return await _dbContext.Blogs.FindAsync(BlogId);
        }

        public Task<IEnumerable<Reaction>> GetReactionByBlog(Guid BlogId)
        {
            throw new NotImplementedException();
        }

        public async Task<Blogging> UpdateBlogging(Blogging blogging)
        {
            var existingBlog = await _dbContext.Blogs.FindAsync(blogging.BlogId);
            if (existingBlog == null)
            {
                throw new InvalidOperationException("Blog not found");
            }
            existingBlog.Title = blogging.Title;
            existingBlog.Content = blogging.Content;
            existingBlog.Image = blogging.Image;
            _dbContext.Blogs.Update(existingBlog);
            await _dbContext.SaveChangesAsync();
            return existingBlog;
        }

    }
}
