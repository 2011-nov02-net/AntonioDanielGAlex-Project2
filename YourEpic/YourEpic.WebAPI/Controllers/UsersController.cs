using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourEpic.Domain;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

namespace YourEpic.WebAPI.Controllers
{
    // api/Users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEpicRepository _epicRepository;

        public UsersController(IAccountRepository accountRepository, IEpicRepository epicRepository)
        {
            _accountRepository = accountRepository;
            _epicRepository = epicRepository;
        }


        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var m_user = await Task.FromResult(_accountRepository.GetUsers());
            if ( m_user is IEnumerable<User> users)
            {
                return Ok(users);
            }
            return NotFound();
        }


        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            var created = await Task.FromResult(_accountRepository.CreateAccount(user));
            if (created)
            {
                return CreatedAtAction(nameof(Get), new { id = user.ID }, user);
            }
            return BadRequest();
        }


        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var d_user = await Task.FromResult(_accountRepository.GetUserByID(id));
            if (d_user is User user)
            {
                return Ok(user);
            }

            return NotFound();
        }


        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            if (_accountRepository.GetUserByID(user.ID) is User)
            {
                var updated = await Task.FromResult(_accountRepository.EditAccount(user));
                if (updated)
                {

                    return Ok();
                }
                else { return BadRequest(); }
            }

            return NotFound();
        }


        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_accountRepository.GetUserByID(id) is User)
            {
                var deleted = await Task.FromResult(_accountRepository.DeleteAccount(id));
                if (deleted)
                {
                    return NoContent();
                }
                else { return BadRequest(); }
            }

            return NotFound();
        }


        // Need to pass in the user id for the route, and the user to call the function
        // GET: api/users/{id}/epics
        [HttpGet("{id}/epics")]
        public async Task<ActionResult<IEnumerable<Epic>>> GetUserEpics(int id, User user)
        {
            var d_epics = await Task.FromResult(_epicRepository.GetPublishersEpics(user));
            if (d_epics is IEnumerable<Epic> epics)
            {
                return Ok(epics);
            }

            return NotFound();
        }
    }
}
