using Application;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ReactionService : IReactionService
    {
        private readonly ApplicationDBContext _dbContext;

        public ReactionService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Reaction> AddReaction(Reaction reaction)
        {
            _dbContext.Reactions.Add(reaction);
            await _dbContext.SaveChangesAsync();
            return reaction;
        }
    }
}
