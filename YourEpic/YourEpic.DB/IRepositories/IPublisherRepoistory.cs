using System;
<<<<<<< HEAD


=======
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4
namespace YourEpic.DB.IRepositories
{
    public interface IPublisherRepoistory
    {
        /// <summary>
        /// Publisher creates a new epic
        /// </summary>
        /// <param name="epic"></param>
<<<<<<< HEAD
        public bool AddEpic(Domain.Models.Epic epic);
=======
        public void AddEpic(Domain.Epic epic);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4

        /// <summary>
        /// Delete Epic By passing in EpicID
        /// </summary>
        /// <param name="epicID"></param>
<<<<<<< HEAD
        public bool DeleteEpic(int epicID);
=======
        public void DeleteEpic(int epicID);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4

        /// <summary>
        /// Add a chapter to an epic
        /// </summary>
        /// <param name="chapter"></param>
<<<<<<< HEAD
        public bool AddChapter(Domain.Models.Chapter chapter);
=======
        public void AddChapter(Domain.Chapter chapter);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4

        /// <summary>
        /// Delete Chapter by passing in ChapterID
        /// </summary>
        /// <param name="chapterID"></param>
<<<<<<< HEAD
        public bool DeleteChapter(int chapterID);
=======
        public void DeleteChapter(int chapterID);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4

        /// <summary>
        /// Publisher wants to edit an existing chapter
        /// </summary>
        /// <param name="chapterID"></param>
<<<<<<< HEAD
        public bool EditChapter(int chapterID);
=======
        public void EditChapter(int chapterID);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4

        /// <summary>
        /// Add categories to the epic (EpicCategory table)
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="epicID"></param>
<<<<<<< HEAD
        public bool CategorizeEpic(int categoryID, int epicID);

        public IEnumerable<Category>
=======
        public void CategorizeEpic(int categoryID, int epicID);
>>>>>>> 5c4db1d56968819077b26dbf724e72ce7fcb55d4
    }
}
