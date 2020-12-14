using System;
namespace YourEpic.DB.IRepositories
{
    public interface ISubscribtionsRepository
    {
        /// <summary>
        /// Subscribe to a Publisher 
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="subscriber"></param>
        public bool SubscribeToPublisher(User subscriber, User publisher);

        /// <summary>
        /// Unsubscribe From a Publisher
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="subscriber"></param>
        public bool UnsubscribeFromPublisher(User subscriber, User publisher);
    }
}
