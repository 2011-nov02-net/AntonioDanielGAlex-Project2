﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.DB.Mappers
{
    public static class RatingMapper
    {
        public static Rating MapFull(Domain.Models.Rating model)
        {
            return new Rating { 
                Id = model.ID,
                Rating1 = model.RatingNumber,
                EpicId = model.RatingEpic.ID,
                RaterId = model.Rater.ID
            };
        }

        public static Domain.Models.Rating Map(Rating entity)
        {
            return new Domain.Models.Rating
            {
                ID = entity.Id,
                RatingNumber = entity.Rating1
            };
        }
    }
}
