using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourEpic.WebAPI.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {

        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IReaderRepository _readerRepository;

        public SubscriptionsController(ISubscriptionRepository subscriptionRepository, IReaderRepository readerRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _readerRepository = readerRepository;
        }

        // GET api/<SubscriptionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_readerRepository.GetEpicsSubscribedTo(id) is IEnumerable<Epic> subscriptions)
            {
                return Ok(subscriptions);
            }
            return NotFound();
        }

        [HttpPost("{publisherID}/subscribee/{subscriber}")]

        public IActionResult Post(int subscriber, int publisherID)
        {
            if (_subscriptionRepository.SubscribeToPublisher(subscriber, publisherID))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{publisherID}/subscribee/{subscriber}")]
        public IActionResult Delete(int subscriber, int publisherID)
        {
            if (_subscriptionRepository.UnsubscribeFromPublisher(subscriber, publisherID))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
