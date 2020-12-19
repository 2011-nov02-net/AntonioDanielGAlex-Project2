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
    public class ChaptersController : ControllerBase
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IEpicRepository _epicRepository;

        public ChaptersController(IChapterRepository chapterRepository, IEpicRepository epicRepository)
        {
            _chapterRepository = chapterRepository;
            _epicRepository = epicRepository;
        }

        // GET: api/chapters/{id}
        [HttpGet("{id}")]
        public ActionResult<Chapter> GetById(int id)
        {
            if (_chapterRepository.GetChapterByID(id) is Chapter chapter)
            {
                return Ok(chapter);
            }
            return NotFound();
        }

        // POST: api/chapters
        [HttpPost]
        public IActionResult Post(Chapter chapter)
        {
            if (_chapterRepository.AddChapter(chapter))
            {
                return CreatedAtAction(nameof(GetById), new { id = chapter.ID }, chapter);
            }
            return BadRequest();
        }


        // PUT: api/chapters/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int chapterID, [FromBody] Chapter newChapter)
        {
            if(_chapterRepository.GetChaptersByEpicID(chapterID) is Chapter)
            {
                _chapterRepository.UpdateChapter(newChapter);

                return NoContent();
            }


            return NotFound();
        }

        // DELETE: api/chapters/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Chapter chapter)
        {
            // Check 
            if (_chapterRepository.GetChapterByID(chapter.ID) is Chapter)
            {
                _chapterRepository.DeleteChapter(chapter);

                return NoContent();
            }
            return NotFound();
        }
    }
}
