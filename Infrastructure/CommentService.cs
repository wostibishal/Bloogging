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
    public class CommentService : ICommentService
    {
        private readonly ApplicationDBContext _context;

        public CommentService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public Task<bool> DeleteComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetCommentById(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetCommentsByBlogId(Guid blogId)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Reaction>> GetReactionByCommentId(Guid BlogId)
        {
            throw new NotImplementedException();
        }
    }

}
