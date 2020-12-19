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
        public async Task<ActionResult<IEnumerable<Epic>>> Get()
        {
            var epics = await Task.FromResult(_epicRepository.GetAllEpics());
            if (epics is IEnumerable<Epic>)
            {
                return Ok(epics);
            }
            return NotFound();
        }

        // GET: api/epics/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Epic>> GetEpicByID(int id)
        {
            var m_epic = await Task.FromResult(_epicRepository.GetEpicByID(id));
            if (m_epic is Epic epic)
            {
                return Ok(epic);
            }

            return NotFound();
        }


        // POST: api/epics/
        [HttpPost]
        public async Task<IActionResult> AddEpic(Epic epic)
        {
            var completed = await Task.FromResult(_epicRepository.AddEpic(epic));
            if (completed)
            {
                return CreatedAtAction(nameof(GetEpicByID), new { id = epic.ID }, epic);
            }
            return BadRequest();
        }

        // Here id is the epicID you want to look at/read
        // GET api/epic/{id}/chapters
        [HttpGet("{id}/chapters")]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChaptersForEpic(int id)
        {
            var m_chapters = await Task.FromResult(_chapterRepository.GetChaptersByEpicID(id));
            if (m_chapters is IEnumerable<Chapter> chapters)
            {
                return Ok(chapters.ToList());
            }

            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_epicRepository.GetEpicByID(id) is Epic epic)
            {

                var completed = await Task.FromResult(_epicRepository.DeleteEpic(epic));
                if (completed)
                {
                    return NoContent();
                }
                else { return BadRequest(); }
            }
            return NotFound();
        }

        // Should pass in the epicID for the path and the rating for the method.
        // POST: /api/epic/{epicID}/ratings
        [HttpPost("{epicID}/ratings")]
        public async Task<IActionResult> PostRating(int epicID, Rating rating)
        {
            var completed = await Task.FromResult(_ratingRepository.AddRatingForEpic(rating));
            if (completed)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
