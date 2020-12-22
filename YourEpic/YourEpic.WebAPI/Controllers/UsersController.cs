using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourEpic.Domain;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;
using YourEpic.WebAPI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var m_user = await Task.FromResult(_accountRepository.GetUsers());
            if ( m_user.Select(Mappers.UserModelMapper.Map) is IEnumerable<UserModel> users)
            {
                return Ok(users);
            }
            return NotFound();
        }

        // POST: api/users
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(UserModel user)
        {
            var created = await Task.FromResult(_accountRepository.CreateAccount(Mappers.UserModelMapper.Map(user)));
            if (created)
            {
                return CreatedAtAction(nameof(Get), new { id = user.ID }, user);
            }
            return BadRequest();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var d_user = await Task.FromResult(_accountRepository.GetUserByID(id));
            if (Mappers.UserModelMapper.Map(d_user) is UserModel user)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpGet("email/{email}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> GetUserByEmail(string email)
        {
            var d_user = await Task.FromResult(_accountRepository.GetUserByEmail(email));

            //had to add this because if email not found d_user is null and mapper throws exeption which causes server error (500)
            if(d_user != null)
            {
                if (Mappers.UserModelMapper.Map(d_user) is UserModel user)
                {
                    return Ok(user);
                }
            }

            return NotFound();
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UserModel user)
        {
            if (_accountRepository.GetUserByID(user.ID) is User domain_user)
            {
                var updated = await Task.FromResult(_accountRepository.EditAccount(domain_user));
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
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<EpicModel>>> GetPublisherEpics(int id, UserModel user)
        {
            var d_epics = await Task.FromResult(_epicRepository.GetPublishersEpics(Mappers.UserModelMapper.Map(user)));
            if (d_epics.Select(Mappers.EpicModelMapper.Map) is IEnumerable<EpicModel> epics)
            {
                return Ok(epics);
            }

            return NotFound();
        }
    }
}
