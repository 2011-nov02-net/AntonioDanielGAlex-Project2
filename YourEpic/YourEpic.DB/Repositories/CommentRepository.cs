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

        public IEnumerable<Domain.Models.Comment> GetComments(int epicID)
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
            //still need to implement this one
            return false;
        }

    }
}
