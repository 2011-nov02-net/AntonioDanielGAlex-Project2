using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

namespace YourEpic.DB.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly YourEpicProjectTwoDatabaseContext _context;

        public CommentRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Adds Comment to epic
        /// </summary>
        /// <param name="comment">Domain Model Object</param>
        /// <returns>True if comment successfully added to epic in database</returns>
        public bool AddComment(Domain.Models.Comment comment)
        {
            var dbComment = new Comment
            {
                Id = comment.ID,
                CommenterId = comment.Commenter.ID,
                EpicId = comment.CommentEpic.ID,
                Comment1 = comment.CommentContent,
                DateCreated = (DateTime)comment.Date
            };

            _context.Comments.Add(dbComment);
            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Deletes Comment from database
        /// </summary>
        /// <param name="commentID">Comment id of comment to delete</param>
        /// <returns>True if comment successfully deleted or false if comment non existent in database</returns>
        public bool DeleteComment(int commentID) { 
            var dbComment = _context.Comments
                .FirstOrDefault(c => c.Id == commentID);

            if (dbComment == null)
            {
                return false;
            }

            _context.Comments.Remove(dbComment);
            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Gets all comments of an epic by id
        /// </summary>
        /// <param name="epicID">Target epic id</param>
        /// <returns>All comments of an epic or empty list if epic has no comments yet</returns>
        public IEnumerable<Domain.Models.Comment> GetCommentsForEpic(int epicID)
        {
            var dbComments = _context.Comments
                .Include(c => c.Commenter)
                .Include(c => c.Epic)
                .Where(c => c.EpicId == epicID).ToList();

            if (!dbComments.Any())
            {
                return new List<Domain.Models.Comment>();
            }

            List<Domain.Models.Comment> comments = dbComments.Select(c => new Domain.Models.Comment
            {
                ID = c.Id,
                Commenter = new Domain.Models.User
                {
                    ID = c.Commenter.Id,
                    Name = c.Commenter.Name,
                    Email = c.Commenter.Email
                },
                CommentEpic = new Domain.Models.Epic
                {
                    ID = c.Epic.Id,
                    Title = c.Epic.Name,
                    Date = (DateTime)c.Epic.DateCreated
                },
                CommentContent = c.Comment1,
                Date = (DateTime)c.DateCreated
            }).ToList();
            return comments;
        }

        public bool RespondToComment(int commentID, Domain.Models.Comment comment)
        {
            var dbComment = _context.Comments.FirstOrDefault(c => c.Id == commentID);

            if (dbComment == null)
            {
                //comment to respond to doesn't exist
                return false;
            }

            dbComment = new Comment
            {
                Id = comment.ID,
                CommenterId = comment.Commenter.ID,
                EpicId = comment.CommentEpic.ID,
                Comment1 = comment.CommentContent,
                DateCreated = (DateTime)comment.Date,
                ReplyToComment = commentID
            };

            _context.Comments.Add(dbComment);
            _context.SaveChanges();

            return true;
        }
    }
}
