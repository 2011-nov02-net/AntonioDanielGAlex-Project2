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
        [Authorize]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> Get([FromQuery]string name = null)
        {
            var categories = await Task.FromResult(_categoryRepository.GetCategories(name));
            if (categories.Select(Mappers.CategoryModelMapper.Map) is IEnumerable<CategoryModel> retrievedCats)
            {
                return Ok(retrievedCats);
            }

            return NotFound();
        }

        // POST: api/categories/epic/{epicID}
        [HttpPost("epic/{epicID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody]IEnumerable<CategoryModel> categoriesToAdd, int epicID)
        {
            var pass = await Task.FromResult(_categoryRepository.CategorizeEpic(categoriesToAdd.Select(Mappers.CategoryModelMapper.Map), epicID));
            if (pass)
            {
                return Ok();
            }
            return BadRequest();
        }

        // POST: api/categories
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> NewCategory(CategoryModel category)
        {
            var domain_category = Mappers.CategoryModelMapper.Map(category);
            var pass = await Task.FromResult(_categoryRepository.AddCategory(domain_category.Name));
            if (pass)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
