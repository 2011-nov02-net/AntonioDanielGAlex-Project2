using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;
using YourEpic.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourEpic.WebAPI.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {

        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionsController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        // GET api/<SubscriptionsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Task.FromResult(_subscriptionRepository.GetMySubscriptions(id));
            if (result.Select(Mappers.SubscriptionModelMapper.Map) is IEnumerable<SubscriptionModel> subscriptions)
            {
                return Ok(subscriptions);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(SubscriptionModel subscription)
        {
            var created = await Task.FromResult(_subscriptionRepository.SubscribeToPublisher(subscription.Subscriber.ID, subscription.Publisher.ID));
            if (created)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{publisherID}/subscribee/{subscriber}")]
        [Authorize]
        public async Task<IActionResult> Delete(int subscriber, int publisherID)
        {
            var deleted = await Task.FromResult(_subscriptionRepository.UnsubscribeFromPublisher(subscriber, publisherID));
            if (deleted)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
