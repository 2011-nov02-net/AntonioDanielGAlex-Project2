using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.WebAPI.Models;

namespace YourEpic.WebAPI.Mappers
{
    public static class RatingModelMapper
    {
        public static RatingModel Map(Domain.Models.Rating rating)
        {
            return new RatingModel
            {
                ID = rating.ID,
                RaterID = rating.Rater.ID,
                EpicID = rating.RatingEpic.ID,
                Rater = rating.Rater.Name,
                RatingNumber = rating.RatingNumber
            };
        }

        public static Domain.Models.Rating Map(RatingModel rating)
        {
            return new Domain.Models.Rating
            {
                ID = rating.ID,
                Rater = new Domain.Models.User { ID = rating.RaterID, Name = rating.Rater },
                RatingEpic = new Domain.Models.Epic { ID = rating.EpicID },
                RatingNumber = rating.RatingNumber
            };
        }
    }
}
