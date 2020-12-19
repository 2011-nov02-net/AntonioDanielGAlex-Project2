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
            };
        }
    }
}
