using System;
using YourEpic.WebAPI.Models;
using System.Linq;
namespace YourEpic.WebAPI.Mappers
{
    public static class EpicModelMapper
    {
        public static EpicModel Map(Domain.Models.Epic epic) {
            return new EpicModel {
                ID = epic.ID,
                Date = epic.Date,
                Title = epic.Title,
                Concept = epic.Concept,
                DateCompleted = epic.DateCompleted ?? DateTime.MinValue,
                Author = UserModelMapper.Map(epic.Writer),
                Categories = epic.Categories.Select(c => new CategoryModel { ID = c.ID, Name = c.Name }),
                AverageRating = epic.GetAverageRating(),
                ChapterCount = epic.GetChapterCount(),
                CommentCount = epic.GetCommentCount(),
                RatingCount = epic.GetRatingCount()
            };
        }

        public static Domain.Models.Epic Map(EpicModel model) {
            return new Domain.Models.Epic {
                ID = model.ID,
                Date = model.Date,
                Title = model.Title,
                Concept = model.Concept,
                Writer = UserModelMapper.Map(model.Author),
                Categories = model.Categories.Select(CategoryModelMapper.Map),
                DateCompleted = model.DateCompleted ?? DateTime.MinValue
            };
        }

        public static Domain.Models.Epic MapAPItoDomain(EpicModel model) {
            Domain.Models.User author = new Domain.Models.User { ID = model.Author.ID};

            return new Domain.Models.Epic
            {
                Title = model.Title,
                Writer = author,
                Concept = model.Concept
            };
        }
    }
}
