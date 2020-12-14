using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IEpicRepository
    {

        public interface IEpicRepository
        {
            Epic GetEpicByID(int epicID);

            IEnumerable<Epic> GetAllEpics();

            IEnumerable<Epic> GetPublishersEpics(int publisherID);

            bool UpdateEpicTitle(Epic epic);

            Epic GetHighestRatedEpic();

            Epic GetFeaturedEpic();
        }
    }
}
