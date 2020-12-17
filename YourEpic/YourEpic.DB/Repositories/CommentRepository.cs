using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Interfaces;

namespace YourEpic.DB.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public bool AddComment(Domain.Models.Comment comment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComment(int commentID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Comment> GetComments(int epicID)
        {
            throw new NotImplementedException();
        }

        public bool RespondToComment(int commentID, Domain.Models.Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
