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

        public UsersController(IAccountRepository accountRepository, IEpicRepository epicRepository,IPublisherRepository publisherRepository)
        {
            _accountRepository = accountRepository;
            _epicRepository = epicRepository;
            _publisherRepository = publisherRepository;
        }


        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {

            return _accountRepository.GetUsers();
        }


        // POST: api/users
        [HttpPost]
        public IActionResult Post(User user)
        {

            return Ok(user);
        }


        // GET: api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {

            return _accountRepository.GetUserByID(id);
        }


        // PUT: api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(User user)
        {

            _accountRepository.EditAccount(user);

            return NoContent();
        }


        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _accountRepository.DeleteAccount(id);

            return NoContent();
        }

        // GET: api/users/{id}/epics
        [HttpGet]
        public IEnumerable<Epic> GetUserEpics(User user)
        {

            return _epicRepository.GetPublishersEpics(user);
        }


        // POST: api/users/{id}/epics
        [HttpPost]
        public IActionResult AddEpic(Epic epic)
        {

            _publisherRepository.AddEpic(epic);
            return Ok();
        }

    }
}
