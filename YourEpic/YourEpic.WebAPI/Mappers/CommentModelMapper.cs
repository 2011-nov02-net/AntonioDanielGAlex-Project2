using System;
using YourEpic.WebAPI.Models;
namespace YourEpic.WebAPI.Mappers
{
    public static class CommentModelMapper
    {
        public static CommentModel Map(Domain.Models.Comment comment) {
            return new CommentModel {
                ID = comment.ID,
                CommenterName = comment.Commenter.Name,
                CommentContent = comment.CommentContent,
                DateOfComment = comment.Date
            };
        }

        public static Domain.Models.Comment Map(CommentModel model) {
            return new Domain.Models.Comment {
                ID = model.ID,
                Commenter = new Domain.Models.User {ID = model.CommenterID, Name = model.CommenterName},
                ReplyToComment = model.ReplyToComment,
                CommentContent = model.CommentContent
            };
        }
    }
}
