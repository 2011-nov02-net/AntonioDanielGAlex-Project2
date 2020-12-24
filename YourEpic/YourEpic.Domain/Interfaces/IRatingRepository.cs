using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IRatingRepository
    {
        bool AddRatingForEpic(Models.Rating rating);
        bool RemoveRatingForEpic(Models.Rating rating);
        bool UpdateRatingForEpic(Models.Rating rating);
        IEnumerable<Rating> GetMyRatings(int userId);
    }
}
