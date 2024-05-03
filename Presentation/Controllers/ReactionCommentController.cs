using Application;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionCommentController : ControllerBase
    {
        private readonly IReactionCommentService _ReactionCommentService;
        public ReactionCommentController(IReactionCommentService ReactionCommentService)
        {
            _ReactionCommentService = ReactionCommentService;
        }

        [HttpPost, Route("UpvoteCmt")]
        public async Task<IActionResult> Upvote(ReactionComment likecmt)
        {
            var result = await _ReactionCommentService.AddUpvote(likecmt);
            return Ok(result);
        }

        [HttpPost, Route("DownvoteCmt")]
        public async Task<IActionResult> DownVote(ReactionComment likecmt)
        {
            var result = await _ReactionCommentService.AddDownVote(likecmt);
            return Ok(result);
        }

    }
}
