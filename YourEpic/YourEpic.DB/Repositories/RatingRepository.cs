using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Interfaces;

namespace YourEpic.DB.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        public void AddRatingForEpic(Domain.Models.Rating rating)
        {
            var db_rating = Mappers.RatingMapper.MapFull(rating);
        }

        public void RemoveRatingForEpic(Domain.Models.Rating rating)
        {
            throw new NotImplementedException();
        }

        public void UpdateRatingForEpic(Domain.Models.Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
