using System;

namespace YourEpic.Domain.Models
{
    public class Comment
    {
        private readonly int _id;
        private readonly User _commenter;
        private readonly Epic _commentEpic;
        private readonly string _commentContent;
        private readonly DateTime _date;

        public Comment(int id, User user, Epic epic, string comment, DateTime date)
        {
            _id = id;
            _commenter = user;
            _commentEpic = epic;
            _commentContent = comment;
            _date = date;
        }

        public Comment(User user, Epic epic, string comment, DateTime date)
        {
            _commenter = user;
            _commentEpic = epic;
            _commentContent = comment;
            _date = date;
        }

        public int ID => _id;
        public User Commenter => _commenter;
        public Epic CommentEpic => _commentEpic;
        public string CommentContent => _commentContent;
        public DateTime Date => _date;
    }
}
