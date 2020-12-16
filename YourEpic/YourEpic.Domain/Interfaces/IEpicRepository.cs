using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IEpicRepository
    {
        Epic GetEpicByID(int id);

        IEnumerable<Epic> GetAllEpics();

        IEnumerable<Epic> GetPublishersEpics(User user);

        bool UpdateEpicTitle(Epic epic);

        Epic GetHighestRatedEpic();

        Epic GetFeaturedEpic();

        Chapter GetChapter(int id);
    }
}
