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
    public class ReadersController : ControllerBase
    {
        private readonly IReaderRepository _readerRepository;

        public ReadersController(IReaderRepository readerRepository) {
            _readerRepository = readerRepository;
        }

        // GET: api/values
        [HttpGet("/title/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Epic>>> GetByTitle(string name)
        {
            var epics = await Task.FromResult(_readerRepository.SearchForEpicByTitle(name));

            if (epics is IEnumerable<Epic>) {
                return Ok(epics);
            }
            return NotFound();
        }

        // GET api/values/5
        [HttpGet("/category/{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Epic>>> GetByCategory(string category)
        {
            var epics = await Task.FromResult(_readerRepository.SearchForEpicByCategory(category));

            if (epics is IEnumerable<Epic>) {
                return Ok(epics);
            }

            return NotFound();
        }
    }
}
