using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;
using YourEpic.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourEpic.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // GET api/values/5
        [HttpGet("{epicID}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CommentModel>>> Get([FromRoute] int epicID)
        {
            var comments = await Task.FromResult(_commentRepository.GetCommentsForEpic(epicID));

            if (comments.Select(Mappers.CommentModelMapper.Map) is IEnumerable<CommentModel> retrievedComments)
            {
                return Ok(retrievedComments);
            }
            return NotFound();
        }

        // POST api/comments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CommentModel comment)
        {
            if (Mappers.CommentModelMapper.Map(comment) is Comment newComment)
            {
                var pass = await Task.FromResult(_commentRepository.AddComment(newComment));
                if (pass)
                {
                    return CreatedAtAction(nameof(Get), new { epicID = newComment.CommentEpic.ID }, comment);
                }
                return NotFound();
            }
            return BadRequest();
        }

        // POST api/comments
        [HttpPost("comment/{commentID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromRoute] int commentID, CommentModel comment)
        {
            if (Mappers.CommentModelMapper.Map(comment) is Comment newComment)
            {
                var pass = await Task.FromResult(_commentRepository.RespondToComment(commentID, newComment));
                if (pass)
                {
                    return CreatedAtAction(nameof(Get), new { epicID = newComment.CommentEpic.ID }, comment);
                }
                return NotFound();
            }
            return BadRequest();
        }


        // DELETE api/comments/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var pass = await Task.FromResult(_commentRepository.DeleteComment(id));
            if (pass)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
