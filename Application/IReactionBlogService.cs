using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IReactionBlogService
    {
        Task<ReactionResponce> AddUpvote(ReactionBlog like);
        Task<ReactionResponce> AddDownVote(ReactionBlog like);
        Task<ReactionBlog> GetUsersLike(Guid id, string u_id);
        Task DeleteVote(Guid id);

    }
}
