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
    public class UsersController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEpicRepository _epicRepository;
        private readonly IPublisherRepository _publisherRepository;

        public UsersController(IAccountRepository accountRepository, IEpicRepository epicRepository, IPublisherRepository publisherRepository)
        {
            _accountRepository = accountRepository;
            _epicRepository = epicRepository;
            _publisherRepository = publisherRepository;
        }


        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            if (_accountRepository.GetUsers().First() is User)
            {
                return _accountRepository.GetUsers().ToList();
            }
            return NotFound();
        }


        // POST: api/users
        [HttpPost]
        public IActionResult Post(User user)
        {
            _accountRepository.CreateAccount(user);

            return CreatedAtAction(nameof(Get), new { id = user.ID }, user);
        }


        // GET: api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            if (_accountRepository.GetUserByID(id) is User user)
            {
                return user;
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
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Epic>> GetUserEpics(int id, User user)
        {
            if (_epicRepository.GetPublishersEpics(user).First() is Epic)
            {
                return _epicRepository.GetPublishersEpics(user).ToList();
            }


            return NotFound();
        }
    }
}
