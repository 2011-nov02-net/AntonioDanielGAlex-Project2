using System;
using System.Collections.Generic;

namespace YourEpic.DB.IRepositories
{
    public interface IReaderRepository
    {
        /// <summary>
        /// Leave a rating on an epic
        /// </summary>
        /// <param name="rating"></param>
        public bool MakeRating(Rating rating);

        /// <summary>
        /// Get all of the epics by publishers that a reader is subscribed to.
        /// </summary>
        /// <param name="subscriberID"></param>
        /// <returns></returns>
        public IEnumerable<Epic> GetEpicsSubscribedTo(int subscriberID);


        /// <summary>
        /// Search for an Epic by the category/s it has attached to it
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IEnumerable<Epic> SearchForEpicByCategory(string category);


        /// <summary>
        /// Search for an Epic by its title
        ///     returns a list because epics could have the same name, or user might just fill out part of the title 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IEnumerable<Epic> SearchForEpicByTitle(string Title);
    }
}
