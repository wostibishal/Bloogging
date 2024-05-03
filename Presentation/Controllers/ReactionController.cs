using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ReactionController : Controller
    {
        private readonly IReactionService _ReactionService;

        public ReactionController(IReactionService reactionService)
        {
            _ReactionService = reactionService;
        }

        [HttpPost("addReaction")]
        public async Task<IActionResult> AddReaction([FromBody] Reaction reaction)
        {
            var addedReaction = await _ReactionService.AddReaction(reaction);
            return Ok(addedReaction);
        }
    }
}
