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
            IQueryable<Epic> items = _context.Epics.Include(w => w.Writer)
                   .Include(c => c.EpicCategories).ThenInclude(c => c.Category)
                   .Include(ch => ch.Chapters)
                   .Include(r => r.Ratings)
                   .Include(co => co.Comments);

            if (category != null)
            {
                items = items.Where(e => e.EpicCategories.Any(c => c.Category.Name == category));
            }
            if (title != null)
            {
                items = items.Where(e => e.Name == title);
            }
            var m_epics = items.Select(Mappers.EpicMapper.MapFull);

            return m_epics;
        }

        public Domain.Models.Epic GetEpicByID(int id)
        {
            IQueryable<Epic> items = _context.Epics.Include(w => w.Writer)
                      .Include(c => c.EpicCategories).ThenInclude(c => c.Category)
                      .Include(ch => ch.Chapters)
                      .Include(r => r.Ratings)
                      .Include(co => co.Comments);

            return Mappers.EpicMapper.MapFull(items.First(e => e.Id == id));
        }

        public Domain.Models.Epic GetFeaturedEpic()
        {
            IQueryable<Epic> items = _context.Epics.Include(w => w.Writer)
                      .Include(c => c.EpicCategories).ThenInclude(c => c.Category)
                      .Include(ch => ch.Chapters)
                      .Include(r => r.Ratings)
                      .Include(co => co.Comments);

            return Mappers.EpicMapper.MapFull(items.OrderByDescending(e => e.DateCompleted).First());
        }

        public Domain.Models.Epic GetHighestRatedEpic()
        {
            var highestRatedEpic = _context.Ratings.GroupBy(r => new { ID = r.EpicId }).Select(r => new { Average = r.Average(p => p.Rating1), ID = r.Key.ID }).OrderByDescending(r => r.Average).First();

            int epicID = highestRatedEpic.ID;

            IQueryable<Epic> items = _context.Epics.Include(w => w.Writer)
                      .Include(c => c.EpicCategories).ThenInclude(c => c.Category)
                      .Include(ch => ch.Chapters)
                      .Include(r => r.Ratings)
                      .Include(co => co.Comments);

            var db_epic = items.First(e => e.Id == epicID);

            return Mappers.EpicMapper.MapFull(db_epic);
        }

        public IEnumerable<Domain.Models.Epic> GetPublishersEpics(Domain.Models.User user)
        {
            return _context.Epics.Include(w => w.Writer)
                      .Include(c => c.EpicCategories).ThenInclude(c => c.Category)
                      .Include(ch => ch.Chapters)
                      .Include(r => r.Ratings)
                      .Include(co => co.Comments)
                      .Select(Mappers.EpicMapper.MapFull)
                      .Where(e => e.Writer.ID == user.ID);
        }

        public bool UpdateEpic(Domain.Models.Epic epic)
        {
            try
            {
                var db_epic = _context.Epics.First(e=>e.Id == epic.ID);
                db_epic.DateCompleted = epic.DateCompleted;
                db_epic.Name = epic.Title;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool AddEpic(Domain.Models.Epic epic)
        {
            var dbEpic = Mappers.EpicMapper.Map(epic);
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
            var subscriptions = _context.Subscriptions.Include(w => w.Writer).Include(s => s.Subscriber).Where(s => s.SubscriberId == subscriberID);

            var m_subscriptions = subscriptions.Select(Mappers.SubscriptionMapper.Map);

            var m_ids = m_subscriptions.Select(s => s.Publisher.ID);

            var db_epics = _context.Epics.Include(w => w.Writer)
                      .Include(c => c.EpicCategories).ThenInclude(c => c.Category)
                      .Include(ch => ch.Chapters)
                      .Include(r => r.Ratings)
                      .Include(co => co.Comments)
                      .Where(e => m_ids.Contains(e.WriterId));

            return db_epics.Select(Mappers.EpicMapper.MapFull);
        }
    }
}
