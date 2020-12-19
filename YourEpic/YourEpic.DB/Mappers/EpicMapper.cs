using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourEpic.DB.Mappers
{
    public static class EpicMapper
    {
        public static Domain.Models.Epic Map(Epic entity)
        {
            return new Domain.Models.Epic
            {
                ID = entity.Id,
                Title = entity.Name,
                Date = (DateTime)entity.DateCreated,
                Writer = new Domain.Models.User {ID = entity.Writer.Id, Name=entity.Writer.Name }
            };
        }
        public static Epic Map(Domain.Models.Epic model)
        {
            return new Epic
            {
                Id = model.ID,
                DateCreated = model.Date,
                Name = model.Title,
                WriterId = model.Writer.ID
            };
        }

        public static Domain.Models.Epic MapWithRatings(Epic entity)
        {
            return new Domain.Models.Epic
            {
                ID = entity.Id,
                Title = entity.Name,
                Date = (DateTime)entity.DateCreated,
                Ratings = entity.Ratings.Select(RatingMapper.Map),
                RatingAverage = entity.Ratings.Average(r=>r.Rating1)
            };
        }
        public static Domain.Models.Epic MapWithWriter(Epic entity)
        {
            return new Domain.Models.Epic
            {
                ID = entity.Id,
                Title = entity.Name,
                Date = (DateTime)entity.DateCreated,
                Writer = UserMapper.Map(entity.Writer)
            };
        }
    }
}
