using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourEpic.Domain.Interfaces;

namespace YourEpic.DB.Repositories
{
    public class EpicRepository : IEpicRepository
    {

        private readonly YourEpicProjectTwoDatabaseContext _context;

        /// <summary>
        /// A repository managing data access for Store objects,
        /// using Entity Framework.
        /// </summary>
        public EpicRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Domain.Models.Epic> GetAllEpics(string title = null, string category = null)
        {
            IQueryable<Epic> items = _context.Epics
                   .Include(c => c.EpicCategories);

            if (category != null)
            {
                items = items.Where(e=>e.EpicCategories.Any(c=>c.Category.Name == category));
            }

            return _context.Epics.Select(Mappers.EpicMapper.Map);
        }

        public Domain.Models.Epic GetEpicByID(int id)
        {
            return Mappers.EpicMapper.Map(_context.Epics.First(e => e.Id == id));
        }

        public Domain.Models.Epic GetFeaturedEpic()
        {
            return Mappers.EpicMapper.MapWithWriter(_context.Epics.Include(w=>w.Writer).OrderByDescending(e => e.DateCompleted).First());
        }

        public Domain.Models.Epic GetHighestRatedEpic()
        {
            var db_epics = _context.Epics.Select(Mappers.EpicMapper.MapWithRatings);
            var highestRatedEpic = new Domain.Models.Epic();
            double highestRating = 0;

            foreach (var epic in db_epics)
            {
                if (epic.AverageRating > highestRating)
                {
                    highestRatedEpic = epic;
                    highestRating = epic.AverageRating;
                }
            }

            return highestRatedEpic;
        }

        public IEnumerable<Domain.Models.Epic> GetPublishersEpics(Domain.Models.User user)
        {
            return _context.Epics.Include(w => w.Writer).Select(Mappers.EpicMapper.MapWithWriter).Where(e => e.Writer.ID == user.ID);
        }

        public bool UpdateEpicTitle(Domain.Models.Epic epic)
        {
            try
            {
                var db_epic = Mappers.EpicMapper.Map(epic);

                _context.Add(db_epic);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool UpdateEpicCompleteness(Domain.Models.Epic epic)
        {
            try
            {
                var db_epic = Mappers.EpicMapper.Map(epic);

                _context.Add(db_epic);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool AddEpic(Domain.Models.Epic epic)
        {
            var dbEpic = new Epic
            {
                Id = epic.ID,
                Name = epic.Title,
                WriterId = epic.Writer.ID,
                DateCreated = epic.Date
            };

            _context.Epics.Add(dbEpic);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteEpic(Domain.Models.Epic epic)
        {

            var dbEpic = _context.Epics.FirstOrDefault(e => e.Id == epic.ID);

            if (dbEpic == null)
            {
                return false;
            }

            _context.Epics.Remove(dbEpic);
            _context.SaveChanges();

            return true;
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
    }
}
