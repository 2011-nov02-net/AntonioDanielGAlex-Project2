using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IChapterRepository
    {
        bool AddChapter(Chapter chapter);
        bool DeleteChapter(Chapter chapter);
        bool UpdateChapter(Chapter chapter);
        Chapter GetChapterByID(int chapterID);
        IEnumerable<Chapter> GetChaptersByEpicID(int epicID);
    }
}
