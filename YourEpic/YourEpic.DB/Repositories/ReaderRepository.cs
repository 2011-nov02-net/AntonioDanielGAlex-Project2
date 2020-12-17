using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using YourEpic.Domain.Interfaces;

namespace YourEpic.DB.Repositories
{
    public class ReaderRepository: IReaderRepository
    {
        private readonly YourEpicProjectTwoDatabaseContext _context;

        public ReaderRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context;
        }



        public IEnumerable<Domain.Models.Epic> GetEpicsSubscribedTo(int subscriberID)
        {

            throw new NotImplementedException();
        }

        public bool MakeRating(Domain.Models.Rating rating)
        {
            _context.Ratings.Add(new Rating { RaterId = rating.Rater.ID, EpicId = rating.RatingEpic.ID, Rating1 = rating.RatingNumber });
            _context.SaveChanges();


            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Epic> SearchForEpicByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Epic> SearchForEpicByTitle(string Title)
        {
            throw new NotImplementedException();
        }
    }
}
