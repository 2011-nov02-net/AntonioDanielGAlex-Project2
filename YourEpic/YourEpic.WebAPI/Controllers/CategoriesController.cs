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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/categories
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await Task.FromResult(_categoryRepository.GetCategories());
            if (categories is IEnumerable<Category> retrievedCats)
            {
                return Ok(retrievedCats);
            }

            return NotFound();
        }

        // POST: api/categories/epic/{epicID}
        [HttpPost("epic/{epicID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(int categoryID, int epicID)
        {
            var pass = await Task.FromResult(_categoryRepository.CategorizeEpic(categoryID, epicID));
            if (pass)
            {
                return Ok();
            }
            return BadRequest();
        }

        // POST: api/categories
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NewCategory(Category category)
        {
            var pass = await Task.FromResult(_categoryRepository.AddCategory(category.Name));
            if (pass)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
