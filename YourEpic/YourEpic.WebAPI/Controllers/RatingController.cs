using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

namespace YourEpic.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository) {
            _ratingRepository = ratingRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Rating>> Get(int id)
        {
            // Might want to make this return an api model in the future. dont want to add
            //    too much in one PR.... but it would be beneficial to change.
            var rating = await Task.FromResult(_ratingRepository.GetRatingByID(id));
            if (rating is Rating) {
                return Ok(rating);
            }
            return NotFound();
        }

        // PUT api/rating/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(Rating rating)
        {
            var pass = await Task.FromResult(_ratingRepository.UpdateRatingForEpic(rating));
            if (pass == true) 
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Rating rating)
        {
            var pass = await Task.FromResult(_ratingRepository.RemoveRatingForEpic(rating));
            if (pass == true) 
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
