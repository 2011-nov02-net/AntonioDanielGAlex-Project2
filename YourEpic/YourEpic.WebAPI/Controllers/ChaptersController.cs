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
        public async Task<ActionResult<Chapter>> GetById(int id)
        {
            var m_chapter = await Task.FromResult(_chapterRepository.GetChapterByID(id));
            if (m_chapter is Chapter chapter)
            {
                return Ok(chapter);
            }

            return NotFound();
        }

        // POST: api/chapters
        [HttpPost]
        public async Task<IActionResult> Post(Chapter chapter)
        {
            var completed = await Task.FromResult(_chapterRepository.AddChapter(chapter));
            if (completed)
            {
                return CreatedAtAction(nameof(GetById), new { id = chapter.ID }, chapter);
            }

            return BadRequest();
        }

        // PUT: api/chapters/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int chapterID, [FromBody] Chapter newChapter)
        {

            if (_chapterRepository.GetChaptersByEpicID(chapterID) is Chapter)
            {
                var completed = await Task.FromResult(_chapterRepository.UpdateChapter(newChapter));
                if (completed)
                {
                    return NoContent();
                }
                else
                { return BadRequest(); }
            }

            return NotFound();
        }

        // DELETE: api/chapters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Chapter chapter)
        {
            // Check 
            if (_chapterRepository.GetChapterByID(chapter.ID) is Chapter)
            {
                var completed = await Task.FromResult(_chapterRepository.DeleteChapter(chapter));
                if (completed)
                {
                    return NoContent();
                }
                else { return BadRequest(); }
            }

            return NotFound();
        }
    }
}
