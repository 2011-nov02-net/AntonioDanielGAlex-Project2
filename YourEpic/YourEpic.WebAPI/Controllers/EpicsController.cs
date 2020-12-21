using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;
using YourEpic.WebAPI.Models;

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
        [Authorize]
        public async Task<ActionResult<IEnumerable<EpicModel>>> Get([FromQuery] string title = null, [FromQuery] string category = null)
        {
            var domain_epics = await Task.FromResult(_epicRepository.GetAllEpics(title, category));

            if (domain_epics.Select(Mappers.EpicModelMapper.Map) is IEnumerable<EpicModel> epics)
            {
                return Ok(epics);
            }
            return NotFound();
        }

        // GET: api/epics/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EpicModel>> GetEpicByID([FromRoute] int id)
        {
            var m_epic = await Task.FromResult(_epicRepository.GetEpicByID(id));

            if (Mappers.EpicModelMapper.Map(m_epic) is EpicModel epic)
            {
                return Ok(epic);
            }

            return NotFound();
        }


        // POST: api/epics/
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddEpic([FromBody] EpicModel epic)
        {
            var domain_epic = Mappers.EpicModelMapper.Map(epic);

            var completed = await Task.FromResult(_epicRepository.AddEpic(domain_epic));

            if (completed)
            {
                return CreatedAtAction(nameof(GetEpicByID), new { id = epic.ID }, epic);
            }
            return BadRequest();
        }

        // Here id is the epicID you want to look at/read
        // GET api/epic/{id}/chapters
        [HttpGet("{id}/chapters")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ChapterModel>>> GetChaptersForEpic(int id)
        {
            var m_chapters = await Task.FromResult(_chapterRepository.GetChaptersByEpicID(id));

            if (m_chapters.Select(Mappers.ChapterModelMapper.Map) is IEnumerable<ChapterModel> chapters)
            {
                return Ok(chapters.ToList());
            }

            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> PostRating(int epicID, RatingModel rating)
        {
            var epic = await Task.FromResult(_epicRepository.GetEpicByID(epicID));

            if (epic is Epic)
            {
                var domain_rating = Mappers.RatingModelMapper.Map(rating);

                var completed = await Task.FromResult(_ratingRepository.AddRatingForEpic(domain_rating));

                if (completed)
                {
                    return Ok();
                }
                return BadRequest();
            }

            return NotFound();
        }

        [HttpGet("featured")]
        [Authorize]
        public async Task<ActionResult<EpicModel>> GetFeatured()
        {
            var domain_epic = await Task.FromResult(_epicRepository.GetFeaturedEpic());

            if (Mappers.EpicModelMapper.Map(domain_epic) is EpicModel epic)
            {
                return Ok(epic);
            }
            return NotFound();
        }

        [HttpGet("highestrated")]
        [Authorize]
        public async Task<ActionResult<EpicModel>> GetHighestRated()
        {
            var domain_epic = await Task.FromResult(_epicRepository.GetHighestRatedEpic());

            if (Mappers.EpicModelMapper.Map(domain_epic) is EpicModel epic)
            {
                return Ok(epic);
            }
            return NotFound();
        }

        [HttpPut("{epicID}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] int epicID, [FromBody] EpicModel epicModel)
        {
            var check_epic = await Task.FromResult(_epicRepository.GetEpicByID(epicID));

            if (check_epic is Epic)
            {
                var model_check = Mappers.EpicModelMapper.Map(check_epic);

                epicModel.ID = model_check.ID;
                epicModel.Date = model_check.Date;
                epicModel.Concept = model_check.Concept;
                epicModel.Author = model_check.Author;
                epicModel.Categories = model_check.Categories;

                if (epicModel.updateCompleted && epicModel.DateCompleted == DateTime.MinValue) { epicModel.DateCompleted = DateTime.UtcNow; }

                var changed = await Task.FromResult(_epicRepository.UpdateEpic(Mappers.EpicModelMapper.Map(epicModel)));

                if (changed)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return NotFound();
        }
    }
}