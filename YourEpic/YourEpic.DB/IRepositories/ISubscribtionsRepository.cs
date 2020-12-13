using System;
namespace YourEpic.DB.IRepositories
{
    public interface ISubscribtionsRepository
    {
        /// <summary>
        /// Subscribe to a Publisher 
        /// </summary>
        /// <param name="publisherID"></param>
        /// <param name="subscriberID"></param>
        public void SubscribeToPublisher(int publisherID, int subscriberID);

        /// <summary>
        /// Unsubscribe From a Publisher
        /// </summary>
        /// <param name="publisherID"></param>
        /// <param name="subscriberID"></param>
        public void UnsubscribeFromPublisher(int publisherID, int subscriberID);
    }
}
