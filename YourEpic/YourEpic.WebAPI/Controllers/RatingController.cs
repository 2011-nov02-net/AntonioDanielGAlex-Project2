using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;
using YourEpic.WebAPI.Models;

namespace YourEpic.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<RatingModel>>> Get(int userId)
        {
            var ratings = await Task.FromResult(_ratingRepository.GetMyRatings(userId));
            if (ratings.Select(Mappers.RatingModelMapper.Map) is IEnumerable<RatingModel> ratingModels)
            {
                return Ok(ratingModels);
            }
            return NotFound();
        }

        // PUT api/rating/5
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int userId, RatingModel rating)
        {
            var pass = await Task.FromResult(_ratingRepository.UpdateRatingForEpic(Mappers.RatingModelMapper.Map(rating)));
            if (pass == true)
            {
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id, RatingModel rating)
        {
            var pass = await Task.FromResult(_ratingRepository.RemoveRatingForEpic(Mappers.RatingModelMapper.Map(rating)));
            if (pass == true)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(RatingModel rating)
        {
            var success = await Task.FromResult(_ratingRepository.AddRatingForEpic(Mappers.RatingModelMapper.Map(rating)));
            if (success == true)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
