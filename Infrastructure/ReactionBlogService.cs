using Application;
using Domain;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ReactionBlogService : IReactionBlogService
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ReactionBlogService(ApplicationDBContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
        }

        public async Task<ReactionBlog> GetUsersLike(Guid id, string u_id)
        {
            var res = await _context.Reactions.FirstOrDefaultAsync(x => x.Blog == id && x.User == u_id);
            return res;

        }

        public async Task<ReactionResponce> AddDownVote(ReactionBlog like)
        {
            if (like == null || like.ReactionType)
                return new ReactionResponce(false, "Invalid operation: like is null or it's an upvote");

            var blogService = new BloggingService(_context, _userManager, _httpContextAccessor);
            var existingLike = await GetUsersLike(like.Blog, like.User);
            var blog = await blogService.GetBlogById(like.Blog);

            if (existingLike != null)
            {
                if (!existingLike.ReactionType)
                {
                    _context.Reactions.Remove(existingLike);
                    blog.DislikeCount--;
                    blog.Popularity = (2 * blog.LikeCount) + (-1 * blog.DislikeCount) + (1 * blog.CommentCount);
                    _context.Blogs.Update(blog);
                    await _context.SaveChangesAsync();
                    return new ReactionResponce(true, "Downvote removed successfully", like);
                }
                else
                {
                    return new ReactionResponce(false, "Cannot downvote an upvoted post");
                }
            }
            else
            {
                _context.Reactions.Add(like);
                blog.DislikeCount++;
                blog.Popularity = (2 * blog.LikeCount) + (-1 * blog.DislikeCount) + (1 * blog.CommentCount);
                _context.Blogs.Update(blog);
                await _context.SaveChangesAsync();
                return new ReactionResponce(true, "Downvote added successfully", like);
            }


        }

        public async Task<ReactionResponce> AddUpvote(ReactionBlog like)
        {
            if (like == null || !like.ReactionType)
                return new ReactionResponce(false, "Invalid operation: like is null or it's a downvote");


            var blogService = new BloggingService(_context, _userManager, _httpContextAccessor);
            var existingLike = await GetUsersLike(like.Blog, like.User);
            var blog = await blogService.GetBlogById(like.Blog);

            if (existingLike != null)
            {
                if (existingLike.ReactionType)
                {
                    _context.Reactions.Remove(existingLike);
                    blog.LikeCount--;
                    blog.Popularity = (2 * blog.LikeCount) + (-1 * blog.DislikeCount) + (1 * blog.CommentCount);
                    _context.Blogs.Update(blog);
                    await _context.SaveChangesAsync();
                    return new ReactionResponce(true, "Upvote removed successfully");
                }
                else
                {
                    return new ReactionResponce(false, "Cannot upvote a downvoted post");
                }
            }
            else
            {
                _context.Reactions.Add(like);
                blog.LikeCount++;
                blog.Popularity = (2 * blog.LikeCount) + (-1 * blog.DislikeCount) + (1 * blog.CommentCount);
                _context.Blogs.Update(blog);
                await _context.SaveChangesAsync();
                return new ReactionResponce(true, "Upvote added successfully", like);
            }


        }

        public async Task DeleteVote(Guid id)
        {
            var like = await _context.Reactions.FirstOrDefaultAsync(x => x.Id == id);
            if (like != null)
            {
                _context.Reactions.Remove(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ReactionResponce> IReactionBlogService.GetUsersLike(Guid id, string u_id)
        {
            var res = await _context.Reactions.FirstOrDefaultAsync(x => x.Blog == id && x.User == u_id);
            return res;
        }
    }
}
