using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.DB.Mappers
{
    public static class ChapterMapper
    {
        public static Domain.Models.Chapter Map(Chapter entity) 
        {
            return new Domain.Models.Chapter
            { 
                ID=entity.Id,
                Date = (DateTime)entity.DateCreated,
                Title = entity.Title,
                Text = entity.Text,
                EpicID = entity.EpicId
            };
        }

        public static Chapter Map(Domain.Models.Chapter model)
        {
            return new Chapter 
            {
                Id = model.ID,
                DateCreated = model.Date,
                Text = model.Text,
                Title = model.Title,
                EpicId = model.EpicID
            };
        }
    }
}
