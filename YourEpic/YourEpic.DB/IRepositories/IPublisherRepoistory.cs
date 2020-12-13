using System;
namespace YourEpic.DB.IRepositories
{
    public interface IPublisherRepoistory
    {
        /// <summary>
        /// Publisher creates a new epic
        /// </summary>
        /// <param name="epic"></param>
        public void AddEpic(Domain.Epic epic);

        /// <summary>
        /// Delete Epic By passing in EpicID
        /// </summary>
        /// <param name="epicID"></param>
        public void DeleteEpic(int epicID);

        /// <summary>
        /// Add a chapter to an epic
        /// </summary>
        /// <param name="chapter"></param>
        public void AddChapter(Domain.Chapter chapter);

        /// <summary>
        /// Delete Chapter by passing in ChapterID
        /// </summary>
        /// <param name="chapterID"></param>
        public void DeleteChapter(int chapterID);

        /// <summary>
        /// Publisher wants to edit an existing chapter
        /// </summary>
        /// <param name="chapterID"></param>
        public void EditChapter(int chapterID);

        /// <summary>
        /// Add categories to the epic (EpicCategory table)
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="epicID"></param>
        public void CategorizeEpic(int categoryID, int epicID);
    }
}
