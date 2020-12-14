using System;
namespace YourEpic.Domain.Interfaces
{
    public interface ISubscriptionRepository
    {
        public bool SubscribeToPublisher(User subscriber, User publisher);

        public bool UnsubscribeFromPublisher(User subscriber, User publisher);
    }
}
