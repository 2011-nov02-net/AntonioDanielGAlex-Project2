using System;
using System.Collections.Generic;

namespace YourEpic.DB.IRepositories
{
    public interface ICommentRepository
    {

        /// <summary>
        /// Add a comment on an Epic
        /// </summary>
        /// <param name="comment"></param>
        public void AddComment(Domain.comment comment);

        /// <summary>
        /// Delete a Comment
        /// </summary>
        /// <param name="comment"></param>
        public void DeleteComment(int commentID);

        /// <summary>
        /// Get all comments on an Epic
        /// </summary>
        /// <param name="epicID"></param>
        public IEnumerable<Domain.comments> GetComments(int epicID);

        /// <summary>
        /// Not sure about this one, dont know where we would display it is a response rather than a general comment
        ///  the commentID parameter is the id of the comment that is being responded to
        /// </summary>
        /// <param name="commentID"></param>
        /// <param name=""></param>
        public void RespondToComment(int commentID, Domain.comment comment);

    }
}
