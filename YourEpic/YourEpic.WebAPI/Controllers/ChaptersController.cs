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
    public class ChaptersController : Controller
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IEpicRepository _epicRepository;

        public ChaptersController(IPublisherRepository publisherRepository, IEpicRepository epicRepository)
        {
            _publisherRepository = publisherRepository;
            _epicRepository = epicRepository;
        }

        // GET: api/chapters/{id}
        [HttpGet("{id}")]
        public ActionResult<Chapter> GetById(int id)
        {
            if (_epicRepository.GetChapter(id) is Chapter chapter)
            {
                return chapter;
            }
            return NotFound();
        }

        // POST: api/chapters
        [HttpPost]
        public IActionResult Post(Chapter chapter)
        {
            _publisherRepository.AddChapter(chapter);
            return CreatedAtAction(nameof(GetById), new { id = chapter.ID }, chapter);
        }


        // PUT: api/chapters/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int chapterID, [FromBody] Chapter newChapter)
        {
            if(_epicRepository.GetChapter(chapterID) is Chapter)
            {
                _publisherRepository.EditChapter(newChapter);

                return NoContent();
            }


            return NotFound();
        }

        // DELETE: api/chapters/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Chapter chapter)
        {
            // Check 
            if (_epicRepository.GetChapter(chapter.ID) is Chapter)
            {
                _publisherRepository.EditChapter(chapter);

                return NoContent();
            }
            return NotFound();
        }
    }
}
