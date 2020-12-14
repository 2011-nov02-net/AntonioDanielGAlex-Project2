using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IEpicRepository
    {

        public interface IEpicRepository
        {
            public Epic GetEpicByID(int epicID);

            public IEnumerable<Epic> GetAllEpics();

            public IEnumerable<Epic> GetPublishersEpics(int publisherID);
        }
    }
}
