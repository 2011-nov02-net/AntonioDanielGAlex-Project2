using System;
using YourEpic.WebAPI.Models;
namespace YourEpic.WebAPI.Mappers
{
    public static class ChapterModelMapper
    {
        public static ChapterModel Map(Domain.Models.Chapter chapter) {
            return new ChapterModel {
                ID = chapter.ID,
                Title = chapter.Title,
                Date = chapter.Date,
                Text = chapter.Text
            };
        }

        public static Domain.Models.Chapter Map(ChapterModel model) {
            return new Domain.Models.Chapter {
                ID = model.ID,
                Title = model.Title,
                ChapterEpic = new Domain.Models.Epic {ID = model.EpicID},
                Text = model.Text
            };
        }
    }
}
