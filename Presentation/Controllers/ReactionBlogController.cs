using Application;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionBlogController : ControllerBase
    {
        private readonly IReactionBlogService _likeBlogService;
        public ReactionBlogController(IReactionBlogService likeBlogService)
        {
            _likeBlogService = likeBlogService;
        }

        [HttpPost, Route("Upvote")]
        public async Task<IActionResult> Upvote(ReactionBlog
            like)
        {
            var result = await _likeBlogService.AddUpvote(like);
            return Ok(result);
        }

        [HttpPost, Route("Downvote")]
        public async Task<IActionResult> DownVote(ReactionBlog like)
        {
            var result = await _likeBlogService.AddDownVote(like);
            return Ok(result);
        }



    }
}
