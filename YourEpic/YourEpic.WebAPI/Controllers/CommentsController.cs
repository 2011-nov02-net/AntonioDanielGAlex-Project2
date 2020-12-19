using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourEpic.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }




        // GET api/values/5
        [HttpGet("{epicID}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Comment>>> Get(int epicID)
        {
            var comments = await Task.FromResult(_commentRepository.GetCommentsForEpic(epicID));
            if (comments is IEnumerable<Comment> retrievedComments) {
                return Ok(retrievedComments);
            }
            return NotFound();
        }

        // POST api/comments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(Comment comment)
        {
            var pass = await Task.FromResult(_commentRepository.AddComment(comment));
            if (pass == true) {
                return Ok();
            }
            return BadRequest();
        }


                // POST api/comments
        [HttpPost("comment/{commentID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(int commentID, Comment comment)
        {
            var pass = await Task.FromResult(_commentRepository.RespondToComment(commentID, comment));
            if (pass == true) {
                return Ok();
            }
            return BadRequest();
        }


        // DELETE api/comments/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var pass = await Task.FromResult(_commentRepository.DeleteComment(id));
            if (pass == true) {
                return NoContent();
            }
            return NotFound();
        }
    }
}
