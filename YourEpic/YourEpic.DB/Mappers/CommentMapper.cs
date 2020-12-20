using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.DB.Mappers
{
    public static class CommentMapper
    {
        public static Domain.Models.Comment Map(Comment entity)
        {
            return new Domain.Models.Comment
            {
                ReplyToComment = entity.ReplyToComment,
                CommentContent = entity.Comment1,
                Date = (DateTime)entity.DateCreated,
                ID = entity.Id
            };
        }
        public static Comment Map(Domain.Models.Comment model)
        {
            return new Comment
            {
                ReplyToComment = model.ReplyToComment,
                Comment1 = model.CommentContent,
                DateCreated = (DateTime)model.Date,
                Id = model.ID
            };
        }
    }
}
