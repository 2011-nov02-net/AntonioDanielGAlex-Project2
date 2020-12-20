using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IEpicRepository
    {
        Epic GetEpicByID(int id);
        IEnumerable<Epic> GetAllEpics(string title = null, string category = null);
        IEnumerable<Epic> GetPublishersEpics(User user);
        Epic GetHighestRatedEpic();
        Epic GetFeaturedEpic();
        bool UpdateEpic(Epic epic);
        bool AddEpic(Epic epic);
        bool DeleteEpic(Epic epic);

    }
}
