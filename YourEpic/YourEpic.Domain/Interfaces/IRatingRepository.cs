using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.Domain.Interfaces
{
    public interface IRatingRepository
    {
        void AddRatingForEpic(Models.Rating rating);
        void RemoveRatingForEpic(Models.Rating rating);
        void UpdateRatingForEpic(Models.Rating rating);
    }
}
