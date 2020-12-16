using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface ISubscriptionRepository
    {
        bool SubscribeToPublisher(User subscriber, User publisher);

        bool UnsubscribeFromPublisher(User subscriber, User publisher);

        IEnumerable<Subscription> GetMySubscriptions(int id);
    }
}
