using System;
<<<<<<< HEAD
using System.Collections.Generic;

=======
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4
namespace YourEpic.DB.IRepositories
{
    public interface IReaderRepository
    {
        /// <summary>
        /// Leave a rating on an epic
        /// </summary>
        /// <param name="rating"></param>
<<<<<<< HEAD
        public bool MakeRating(Rating rating);
=======
        public void MakeRating(Domain.rating rating);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4

        /// <summary>
        /// Get all of the epics by publishers that a reader is subscribed to.
        /// </summary>
        /// <param name="subscriberID"></param>
        /// <returns></returns>
<<<<<<< HEAD
        public IEnumerable<Epic> GetEpicsSubscribedTo(int subscriberID);
=======
        public IEnumerable<Domain.epic> GetEpicsSubscribedTo(int subscriberID);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4


        /// <summary>
        /// Search for an Epic by the category/s it has attached to it
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
<<<<<<< HEAD
        public IEnumerable<Epic> SearchForEpicByCategory(string category);
=======
        public IEnumerable<Domain.Epic> SearchForEpicByCategory(string category);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4


        /// <summary>
        /// Search for an Epic by its title
        ///     returns a list because epics could have the same name, or user might just fill out part of the title 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
<<<<<<< HEAD
        public IEnumerable<Epic> SearchForEpicByTitle(string Title);
=======
        public IEnumerable<Domain.Epic> SearchForEpicByTitle(string Title);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4
    }
}
