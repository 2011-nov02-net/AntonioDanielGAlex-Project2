using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface ICommentRepository
    {

        public bool AddComment(Comment comment);

        public bool DeleteComment(int commentID);

        public IEnumerable<Comment> GetCommentsForEpic(int epicID);

        /// <summary>
        /// Not sure about this one, dont know where we would display it is a response rather than a general comment
        ///  the commentID parameter is the id of the comment that is being responded to
        /// </summary>
        /// <param name="commentID"></param>
        /// <param name="">comment</param>
        public bool RespondToComment(int commentID, Comment comment);


    }
}
