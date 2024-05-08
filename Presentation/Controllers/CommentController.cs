﻿using Application;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost, Route("AddComment")]
        public async Task<IActionResult> AddAddCommentBlog(Comment
            cmt)
        {
            var result = await _commentService.AddComment(cmt);
            return Ok(result);
        }

        [HttpGet, Route("GetComment")]
        public async Task<IActionResult> GetComment(Guid id)
        {
            var result = await _commentService.GetCommentById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet, Route("GetComments")]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await _commentService.GetAllComment();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete, Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(Guid Id)
        {
            await _commentService.DeleteComment(Id);

            return Ok();
        }

        [HttpPut, Route("UpdateComment")]
        public async Task<IActionResult> UpdateComment(Comment cmt)
        {
            var result = await _commentService.UpdateComment(cmt);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
