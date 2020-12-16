using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IPublisherRepository
    {

        bool AddEpic(Epic epic);

        bool DeleteEpic(Epic epic);

        bool AddChapter(Chapter chapter);

        bool DeleteChapter(Chapter chapter);

        bool EditChapter(Chapter chapter);

    }
}
