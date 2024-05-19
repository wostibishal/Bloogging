using Application;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AdminServices : IAdminService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public AdminServices(ApplicationDBContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<int> GetAllTimeBlogPostCount()
        {
            return await _dbContext.Blogs.CountAsync();
        }

        public async Task<int> GetAllTimeCommentCount()
        {
            return await _dbContext.Comments.CountAsync();
        }

        public async Task<int> GetAllTimeDownvoteCount()
        {
            return await _dbContext.Reactions.Where(l => !l.ReactionType).CountAsync();
        }

        public async Task<int> GetAllTimeUpvoteCount()
        {
            return await _dbContext.Reactions.Where(l => l.ReactionType).CountAsync();
        }

        public async Task<int> GetDailyBlogPostCount(DateTime date)
        {
            return await _dbContext.Blogs.CountAsync(b => b.CreatedDate != null && b.CreatedDate.Value.Date == date.Date);
        }

        public async Task<int> GetDailyCommentCount(DateTime date)
        {
            return await _dbContext.Comments.CountAsync(c => c.PostedAt.Date == date.Date);
        }

      

        public async Task<int> GetDailyUpvoteCount(DateTime date)
        {
            // Get the start and end of the specified date
            DateTime startDate = date.Date; // Midnight of the specified date
            DateTime endDate = startDate.AddDays(1); // Midnight of the next day

            // Count the likes within the specified date range
            return await _dbContext.Reactions
                .Where(c => c.CreatedAt >= startDate && c.CreatedAt < endDate && c.ReactionType)
                .CountAsync();
        }
        public async Task<int> GetDailyDownvoteCount(DateTime date)
        {
            // Get the start and end of the specified date
            DateTime startDate = date.Date; // Midnight of the specified date
            DateTime endDate = startDate.AddDays(1); // Midnight of the next day

            // Count the downvotes within the specified date range
            return await _dbContext.Reactions
                .Where(c => c.CreatedAt >= startDate && c.CreatedAt < endDate && !c.ReactionType) // Filter for ReactionType being false (downvote)
                .CountAsync();
        }


#nullable disable
        public async Task<List<string>> GetTop10PopularPosts()
        {
            return await _dbContext.Blogs.OrderByDescending(b => b.Popularity)
                                         .Select(b => b.BlogTitle)
                                         .Take(10)
                                         .ToListAsync();
        }

        public async Task<List<string>> GetTop10PopularBloggers()
        {
            return await _dbContext.Blogs.GroupBy(b => b.User)
                                         .OrderByDescending(g => g.Count())
                                         .Select(g => g.Key)
                                         .Take(10)
                                         .ToListAsync();
        }

        

        public Task<List<string>> GetTop10PopularPostsByMonth(int month, int year)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetTop10PopularBloggersByMonth(int month, int year)
        {
            var bloggerPopularity = await _dbContext.Blogs
               .Include(x => x.UserFK)
               .GroupBy(x => x.UserFK.Id) // Assuming UserId is the foreign key linking to the User table
               .Select(g => new {
                   UserId = g.Key,
                   TotalPopularity = g.Sum(x => x.Popularity),
                   User = g.FirstOrDefault().UserFK
               })
               .OrderByDescending(x => x.TotalPopularity)
               .Take(10)
               .ToListAsync();

            var topTenBloggers = bloggerPopularity.Select(x => x.UserId).ToList();

            return topTenBloggers;
        }
    }
}
