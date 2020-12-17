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

        public IEnumerable<Domain.Models.Epic> GetAllEpics()
        {
            return _context.Epics.Select(Mappers.EpicMapper.Map);
        }

        public Domain.Models.Chapter GetChapter(int chapterID)
        {
            return Mappers.ChapterMapper.Map(_context.Chapters.First(c => c.Id == chapterID));
        }

        public IEnumerable<Domain.Models.Chapter> GetChapters(int epicID)
        {
            return _context.Chapters.Where(e => e.EpicId == epicID).Select(Mappers.ChapterMapper.Map);
        }

        public Domain.Models.Epic GetEpicByID(int id)
        {
            return Mappers.EpicMapper.Map(_context.Epics.First(e => e.Id == id));
        }

        public Domain.Models.Epic GetFeaturedEpic()
        {
            throw new NotImplementedException();
            //return _context.Epics.OrderByDescending(e => e.DateCompleted).First();
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
    }
}
