using Domain;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICommentService
    {
        Task<CommentResponce> AddComment(Comment comments);
        Task<CommentResponce> UpdateComment(Comment comments);
        Task<CommentResponce> DeleteComment(Guid id);
        Task<Comment> GetCommentById(Guid id);
        Task<IEnumerable<Comment>> GetAllComment(Guid id);
    }
}
