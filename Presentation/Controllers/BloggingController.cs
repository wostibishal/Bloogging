using Application;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class BloggingController : Controller
    {
        private readonly IBloggingService _BloggingService;

        public BloggingController(IBloggingService bloggingService)
        {
            _BloggingService = bloggingService;
        }

        [HttpPost, Route("AddBlog")]

        public async Task<IActionResult> AddBlogging(Blogging blogging)
        {
            var addBlogging = await _BloggingService.AddBlogging(blogging);
            return Ok(addBlogging);
        }

        [HttpPut, Route("UpdateBlog")]
        public async Task<IActionResult> UpdateBlogging(Blogging blogging)
        {
            try
            {
                var updatedBlogging = await _BloggingService.UpdateBlogging(blogging);
                if (updatedBlogging == null)
                {
                    return NotFound("Blog not found.");
                }
                return Ok(updatedBlogging);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("DeleteBlog/{blogId}")]
        public async Task<IActionResult> DeleteBlogging(Guid blogId)
        {
            bool isDeleted = await _BloggingService.DeleteBlogging(blogId);
            if (!isDeleted)
            {
                return NotFound("Blog not found.");
            }
            return Ok();
        }

        [HttpGet, Route("GetBlog/{blogId}")]
        public async Task<IActionResult> GetBloggingById(Guid blogId)
        {
            var blogging = await _BloggingService.GetBloggingById(blogId);
            if (blogging == null)
            {
                return NotFound("Blog not found.");
            }
            return Ok(blogging);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet, Route("GetAllBlogs")]
        public async Task<IActionResult> GetAllBloggings()
        {
            var bloggings = await _BloggingService.GetAllBloggings();
            return Ok(bloggings);
        }


    }
}
