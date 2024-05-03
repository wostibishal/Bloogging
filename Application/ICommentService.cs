using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICommentService
    {
        Task<Comment> AddComment(Comment comment);
        Task<Comment> UpdateComment(Comment comment);
        Task<bool> DeleteComment(Guid commentId);
        Task<Comment> GetCommentById(Guid commentId);
        Task<IEnumerable<Comment>> GetCommentsByBlogId(Guid blogId);
        Task<IEnumerable<Reaction>> GetReactionByCommentId(Guid BlogId);
    }
}
