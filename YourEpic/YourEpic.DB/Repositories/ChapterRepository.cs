using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

namespace YourEpic.DB.Repositories
{
    public class ChapterRepository : IChapterRepository
    {

        private readonly YourEpicProjectTwoDatabaseContext _context;

        public ChapterRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool AddChapter(Domain.Models.Chapter chapter)
        {
            var dbEpic = _context.Epics
                .FirstOrDefault(e => e.Id == chapter.ChapterEpic.ID);

            //Epic does not exist in database return false
            if (dbEpic == null)
            {
                return false;
            }

            var dbChapter = new Chapter
            {
                Id = chapter.ID,
                Title = chapter.Title,
                EpicId = chapter.ChapterEpic.ID,
                DateCreated = chapter.Date,
                Text = chapter.Text
            };

            _context.Chapters.Add(dbChapter);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteChapter(Domain.Models.Chapter chapter)
        {
            var dbChapter = _context.Chapters.FirstOrDefault(c => c.Id == chapter.ID);

            //not really sure what remove does when chapter doesn't exist so 
            //return false now.
            if (dbChapter == null)
            {
                return false;
            }

            _context.Chapters.Remove(dbChapter);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateChapter(Domain.Models.Chapter chapter)
        {
            var dbChapter = _context.Chapters.FirstOrDefault(c => c.Id == chapter.ID);

            
            if (dbChapter == null)
            {
                //chapter doesn't exist
                return false;
            }

            dbChapter.Title = chapter.Title;
            dbChapter.Text = chapter.Text;

            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Domain.Models.Chapter> GetChaptersByEpicID(int epicID)
        {
            return _context.Chapters.Where(e => e.EpicId == epicID).Select(Mappers.ChapterMapper.Map);
        }

        public Domain.Models.Chapter GetChapterByID(int chapterID)
        {
            return Mappers.ChapterMapper.Map(_context.Chapters.Where(e => e.Id == chapterID).FirstOrDefault());
        }
    }
}
