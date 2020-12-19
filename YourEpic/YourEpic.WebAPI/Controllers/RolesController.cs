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
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
    
        // GET: api/roles
        [HttpGet("{roles}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            var roles = await Task.FromResult(_rolesRepository.GetRoles());
            if (roles is IEnumerable<Role>)
            {
                return Ok(roles);
            }
            return NotFound();
        }
    }
}
