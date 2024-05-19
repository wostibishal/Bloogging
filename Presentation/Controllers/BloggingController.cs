using Application;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly IBloggingService _blogService;

        public BlogController(IBloggingService blogService)
        {
            _blogService = blogService;
        }
      
        [HttpPost, Route("AddBlog")]
        public async Task<IActionResult> AddBlog(Blogging 
            std)
        {
            var result = await _blogService.AddBlog(std);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet, Route("GetBlog")]
        public async Task<IActionResult> GetABlog(Guid id)
        {
            var result = await _blogService.GetBlogById(id);
            if (result == null)
            {
                return NotFound();
                }
            return Ok(result);
            }

        [AllowAnonymous]
        [HttpGet, Route("GetBlogs")]
        public async Task<IActionResult> GetAllBlogs()
            {
            var result = await _blogService.GetAllBlogs();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
      
        [HttpDelete, Route("DeleteBlog")]
        public async Task<IActionResult> DeleteBlog(Guid Id)
            {
            await _blogService.DeleteBlog(Id);

            return Ok();
        }
       
        [HttpPut, Route("UpdateBlog")]
        public async Task<IActionResult> UpdateBlog(Blogging blog)
        {
            var result = await _blogService.UpdateBlog(blog);
            if (result == null)
            {
                return NotFound();
        }
            return Ok(result);
        }

        [HttpGet("GetBlogspag")]
        public async Task<ActionResult<IEnumerable<Blogging>>> GetAllBlogsPagination(int pageNumber, int pageSize)
        {

            var result = await _blogService.GetAllBlogsPagination(pageNumber, pageSize);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
    }
}
