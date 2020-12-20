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
                Concept = entity.Concept,
                DateCompleted = entity.DateCompleted ?? DateTime.MinValue
            };
        }
        public static Epic Map(Domain.Models.Epic model)
        {
            return new Epic
            {
                Id = model.ID,
                DateCreated = model.Date,
                Name = model.Title,
                WriterId = model.Writer.ID,
                DateCompleted = model.DateCompleted,
                Concept = model.Concept
            };
        }

        public static Domain.Models.Epic MapWithRatings(Epic entity)
        {
            return new Domain.Models.Epic
            {
                ID = entity.Id,
                Title = entity.Name,
                Date = (DateTime)entity.DateCreated,
                Ratings = entity.Ratings.Select(RatingMapper.Map)
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
        public static Domain.Models.Epic MapWithCategoryAndWriter(Epic entity)
        {
            return new Domain.Models.Epic
            {
                ID = entity.Id,
                Title = entity.Name,
                Date = (DateTime)entity.DateCreated,
                Concept = entity.Concept,
                Writer = UserMapper.Map(entity.Writer),
                Categories = entity.EpicCategories.Select(c => CategoryMapper.Map(c.Category))
            };
        }

        public static Domain.Models.Epic MapFull(Epic entity)
        {
            return new Domain.Models.Epic
            {
                ID = entity.Id,
                Title = entity.Name,
                Date = (DateTime)entity.DateCreated,
                Concept = entity.Concept,
                DateCompleted = entity.DateCompleted ?? DateTime.MinValue,
                Writer = UserMapper.Map(entity.Writer),
                Categories = entity.EpicCategories.Select(c => CategoryMapper.Map(c.Category)),
                Ratings = entity.Ratings.Select(RatingMapper.Map),
                Comments = entity.Comments.Select(CommentMapper.Map),
                Chapters = entity.Chapters.Select(ChapterMapper.Map)
            };
        }
    }
}
