using Application;
using Domain;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReactionCommentServices : IReactionCommentService
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReactionCommentServices(ApplicationDBContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
        }


        public async Task<ReactionComment> GetCommentsUserLike(Guid id, string u_id)
        {
            var res = await _context.ReactionComments.FirstOrDefaultAsync(x => x.Comment == id && x.User == u_id);
            return res;

        }

        public async Task<ReactionCommentResponce> AddDownVote(ReactionComment likecmt)
        {
            if (likecmt == null || likecmt.ReactionType)
                return new ReactionCommentResponce(false, "Invalid operation: like is null or it's an upvote");

            var commentService = new CommentService(_context);
            var existingLike = await GetCommentsUserLike(likecmt.Comment, likecmt.User);
            var comments = await commentService.GetCommentById(likecmt.Comment);

            if (existingLike != null)
            {
                if (!existingLike.ReactionType)
                {
                    _context.ReactionComments.Remove(existingLike);
                    comments.DislikeCount--;

                    _context.Comments.Update(comments);
                    await _context.SaveChangesAsync();
                    return new ReactionCommentResponce(true, "Downvote removed successfully", likecmt);
                }
                else
                {
                    return new ReactionCommentResponce(false, "Cannot downvote an upvoted post");
                }
            }
            else
            {
                _context.ReactionComments.Add(likecmt);
                comments.DislikeCount++;

                _context.Comments.Update(comments);
                await _context.SaveChangesAsync();
                return new ReactionCommentResponce(true, "Downvote added successfully", likecmt);
            }


        }
        public async Task<ReactionCommentResponce> AddUpvote(ReactionComment likecmt)
        {
            if (likecmt == null || !likecmt.ReactionType)
                return new ReactionCommentResponce(false, "Invalid operation: like is null or it's an downvote");

            var commentService = new CommentService(_context);
            var existingLike = await GetCommentsUserLike(likecmt.Comment, likecmt.User);
            var comments = await commentService.GetCommentById(likecmt.Comment);

            if (existingLike != null)
            {
                if (existingLike.ReactionType)
                {
                    _context.ReactionComments.Remove(existingLike);
                    comments.LikeCount--;

                    _context.Comments.Update(comments);
                    await _context.SaveChangesAsync();
                    return new ReactionCommentResponce(true, "Upvote removed successfully", likecmt);
                }
                else
                {
                    return new ReactionCommentResponce(false, "Cannot downvote an upvoted post");
                }
            }
            else
            {
                _context.ReactionComments.Add(likecmt);
                comments.LikeCount++;

                _context.Comments.Update(comments);
                await _context.SaveChangesAsync();
                return new ReactionCommentResponce(true, "Upvote added successfully", likecmt);
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
    }
}
