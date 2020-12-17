using System;
using System.Collections.Generic;
using System.Linq;
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
            var epics = _context.Subscriptions.Where(s => s.SubscriberId == subscriberID)
                .Join(_context.Epics, s => s.WriterId, e => e.WriterId, (s, e) => new Epic
                {
                    Id = e.Id,
                    Name = e.Name,
                    WriterId = e.WriterId,
                    Concept = e.Concept,
                    DateCreated = (DateTime)e.DateCreated
                });

            var domainEpics = epics.Select(e => new Domain.Models.Epic { ID = e.Id, Title = e.Name });


            return domainEpics;

        }

        public bool MakeRating(Domain.Models.Rating rating)
        {
            _context.Ratings.Add(new Rating { RaterId = rating.Rater.ID, EpicId = rating.RatingEpic.ID, Rating1 = rating.RatingNumber });
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Domain.Models.Epic> SearchForEpicByCategory(string category)
        {
            var epics = _context.Categories.Where(c => c.Name.Contains(category))
                .Join(_context.EpicCategories, c => c.Id, ec => ec.CategoryId, (c, ce) => new EpicCategory
                {


                    EpicId = ce.EpicId,
                    CategoryId = c.Id



                });

            var ep = _context.Epics.Join(epics, e => e.Id, ep => ep.EpicId, (e, ep) => new Epic
            {
                Id = e.Id,
                Name = e.Name,
                WriterId = e.WriterId,
                Concept = e.Concept,
                DateCreated = (DateTime)e.DateCreated


            });

            var domainEpics = ep.Select(e => new Domain.Models.Epic { ID = e.Id, Title = e.Name });


            return domainEpics;
        }

        public IEnumerable<Domain.Models.Epic> SearchForEpicByTitle(string Title)
        {
            var epics = _context.Epics.Where(e => e.Name.Contains(Title));


            var domainEpics = epics.Select(e => new Domain.Models.Epic { ID = e.Id, Title = e.Name});


            return domainEpics;
        }
    }
}
