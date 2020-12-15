using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IPublisherInterface
    {

        bool AddEpic(Epic epic);

        bool DeleteEpic(int epicID);

        bool AddChapter(Domain.Models.Chapter chapter);

        bool DeleteChapter(int chapterID);

        bool EditChapter(int chapterID);
    }
}
