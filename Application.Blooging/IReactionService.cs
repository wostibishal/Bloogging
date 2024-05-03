using Domain.Entities;
namespace Application.Blooging
{
    public interface IReactionService
    {
        public interface IReactionRepository
        {
            Task AddReactionAsync(Reaction reaction);
            Task<IEnumerable<Reaction>> GetReactionsByBlogIdAsync(Guid blogId);
        }
        //public class ReactionService : IReactionService
        //{
        //    private readonly IReactionRepository _reactionRepository;

        //    public ReactionService(IReactionRepository reactionRepository)
        //    {
        //        _reactionRepository = reactionRepository;
        //    }

        //    public async Task AddReactionAsync(ReactionDto reactionDto)
        //    {
        //        var reaction = new Reaction
        //        {
        //            BlogId = reactionDto.BlogId,
        //            Upvote = reactionDto.Upvote,
        //            Downvote = reactionDto.Downvote,
        //            Comment = reactionDto.Comment
        //        };
        //        await _reactionRepository.AddReactionAsync(reaction);
        //    }
        //}
    }
}
