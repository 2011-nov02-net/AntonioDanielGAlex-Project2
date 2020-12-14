
using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IPublisherInterface
    {

        public bool AddEpic(Epic epic);

        public bool DeleteEpic(int epicID);

        public bool AddChapter(Domain.Models.Chapter chapter);

        public bool DeleteChapter(int chapterID);

        public bool EditChapter(int chapterID);

        public bool CategorizeEpic(int categoryID, int epicID);

        public IEnumerable<Category> GetCategories();


    }
}
