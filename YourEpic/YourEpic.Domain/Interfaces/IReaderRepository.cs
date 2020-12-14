
using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IReaderRepository
    {

        bool MakeRating(Rating rating);

        IEnumerable<Epic> GetEpicsSubscribedTo(int subscriberID);

        IEnumerable<Epic> SearchForEpicByCategory(string category);

        IEnumerable<Epic> SearchForEpicByTitle(string Title);
    }
}
