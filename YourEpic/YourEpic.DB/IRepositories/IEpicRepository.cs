using System;
using System.Collections.Generic;

namespace YourEpic.DB.IRepositories
{
    public interface IEpicRepository
    {
        /// <summary>
        /// Return the single epic you want to look at.
        ///     make sure to return the chapters list in order of chapter
        /// </summary>
        /// <param name="epicID"></param>
        /// <returns></returns>
        public Epic GetEpicByID(int epicID);

        /// <summary>
        /// Get all of the epics that have been published
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Epic> GetAllEpics();

        /// <summary>
        /// When youre looking at a Publisher, use this to get all of his/her epics
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Epic> GetPublishersEpics(int publisherID);


        

    }
}
