using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourEpic.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicsController : ControllerBase
    {
        private readonly IEpicRepository _epicRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly IRatingRepository _ratingRepository;

        public EpicsController(IEpicRepository epicRepository, IChapterRepository chapterRepository, IRatingRepository ratingRepository)
        {
            _epicRepository = epicRepository;
            _chapterRepository = chapterRepository;
            _ratingRepository = ratingRepository;
        }


        // GET: api/epics
        [HttpGet]
        public ActionResult<IEnumerable<Epic>> Get()
        {
            if (_epicRepository.GetAllEpics() is IEnumerable<Epic>)
            {
                return Ok(_epicRepository.GetAllEpics().ToList());
            }
            return NotFound();


        }

        // GET: api/epics/{id}
        [HttpGet("{id}")]
        public ActionResult<Epic> GetEpicByID(int id)
        {
            if (_epicRepository.GetEpicByID(id) is Epic epic)
            {
                return Ok(epic);
            }

            return NotFound();
        }


        // POST: api/epics/
        [HttpPost]
        public IActionResult AddEpic(Epic epic)
        {
            if (_epicRepository.AddEpic(epic))
            {
                return CreatedAtAction(nameof(GetEpicByID), new { id = epic.ID }, epic);
            }
            return BadRequest();  
        }

        // Here id is the epicID you want to look at/read
        // GET api/epic/{id}/chapters
        [HttpGet("{id}/chapters")]
        public ActionResult<IEnumerable<Chapter>> GetChapters(int id)
        {
            if (_chapterRepository.GetChaptersByEpicID(id) is IEnumerable<Chapter> chapters)
            {
                return Ok(chapters.ToList());
            }

            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_epicRepository.GetEpicByID(id) is Epic epic)
            {
                _epicRepository.DeleteEpic(epic);
                return NoContent();
            }
            return NotFound();
        }

        // Should pass in the epicID for the path and the rating for the method.
        // POST: /api/epic/{epicID}/ratings
        [HttpPost("{epicID}/ratings")]
        public IActionResult PostRating(int epicID, Rating rating)
        {
            if (_ratingRepository.AddRatingForEpic(rating))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
