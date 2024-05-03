using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IReactionCommentService
    {
        Task<ReactionCommentResponce> AddUpvote(ReactionComment likecmt);
        Task<ReactionCommentResponce> AddDownVote(ReactionComment likecmt);
        Task<ReactionComment> GetCommentsUserLike(Guid id, string u_id);
        Task DeleteVote(Guid id);
    }
}
