using System;
namespace YourEpic.DB.IRepositories
{
    public interface ISubscribtionsRepository
    {
        /// <summary>
        /// Subscribe to a Publisher 
        /// </summary>
<<<<<<< HEAD
        /// <param name="publisher"></param>
        /// <param name="subscriber"></param>
        public bool SubscribeToPublisher(User subscriber, User publisher);
=======
        /// <param name="publisherID"></param>
        /// <param name="subscriberID"></param>
        public void SubscribeToPublisher(int publisherID, int subscriberID);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4

        /// <summary>
        /// Unsubscribe From a Publisher
        /// </summary>
<<<<<<< HEAD
        /// <param name="publisher"></param>
        /// <param name="subscriber"></param>
        public bool UnsubscribeFromPublisher(User subscriber, User publisher);
=======
        /// <param name="publisherID"></param>
        /// <param name="subscriberID"></param>
        public void UnsubscribeFromPublisher(int publisherID, int subscriberID);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4
    }
}
