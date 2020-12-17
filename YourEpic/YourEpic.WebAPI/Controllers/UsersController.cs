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
        public ActionResult<IEnumerable<User>> Get()
        {
            if (_accountRepository.GetUsers() is IEnumerable<User>)
            {
                IEnumerable<User> users = _accountRepository.GetUsers();
                return Ok(users);
            }
            return NotFound();
        }


        // POST: api/users
        [HttpPost]
        public IActionResult Post(User user)
        {
            if (_accountRepository.CreateAccount(user))
            {
                return CreatedAtAction(nameof(Get), new { id = user.ID }, user);
            }
            return BadRequest();
        }


        // GET: api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            if (_accountRepository.GetUserByID(id) is User user)
            {
                return Ok(user);
            }

            return NotFound();
        }


        // PUT: api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {

            if (_accountRepository.GetUserByID(user.ID) is User)
            {
                _accountRepository.EditAccount(user);
            }

            return NotFound();
        }


        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_accountRepository.GetUserByID(id) is User)
            {
                _accountRepository.DeleteAccount(id);
                return NoContent();
            }

            return NotFound();
        }


        // Need to pass in the user id for the route, and the user to call the function
        // GET: api/users/{id}/epics
        [HttpGet("{id}/epics")]
        public ActionResult<IEnumerable<Epic>> GetUserEpics(int id, User user)
        {
            if (_epicRepository.GetPublishersEpics(user) is IEnumerable<Epic>)
            {
                return Ok(_epicRepository.GetPublishersEpics(user).ToList());
            }


            return NotFound();
        }
    }
}
