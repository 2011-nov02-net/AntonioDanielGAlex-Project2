using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface ISubscriptionRepository
    {
        bool SubscribeToPublisher(int subscriberID, int publisherID);

        bool UnsubscribeFromPublisher(int subscriberID, int publisherID);
    }
}
