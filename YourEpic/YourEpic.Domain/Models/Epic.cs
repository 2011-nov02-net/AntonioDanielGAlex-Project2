using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Models;
using System.Linq;

namespace YourEpic.Domain.Models
{
    public class Epic
    {
        private readonly int _id;
        private readonly string _title;
        private readonly User _writer;
        private readonly DateTime _date;
        private readonly List<Chapter> _chapters;
        private readonly List<Comment> _comments;
        private readonly List<Rating> _ratings;

        public Epic(int id, string title, User user, DateTime date, List<Chapter> chapters, List<Comment> comments, List<Rating> ratings)
        {
            _id = id;
            _title = title;
            _writer = user;
            _date = date;
            _chapters = chapters;
            _comments = comments;
            _ratings = ratings;
        }

        public Epic(string title, User user, DateTime date)
        {
            _title = title;
            _writer = user;
            _date = date;
        }

        public int ID => _id;
        public string Title => _title;
        public User Writer => _writer;
        public DateTime Date => _date;
        public List<Chapter> Chapters => _chapters;
        public List<Comment> Comments => _comments;
        public List<Rating> Ratings => _ratings;
        public int ChapterCount => _chapters.Count;
        public int CommentCount => _comments.Count;
        public int RatingCount => _ratings.Count;

        public Chapter GetChapterById(int id)
        {
            Chapter chapter = _chapters.FirstOrDefault(c => c.ID == id);

            return chapter;
        }

        public Chapter GetChapterByTitle(string title)
        {
            Chapter chapter = _chapters.FirstOrDefault(c => c.Title == title);

            return chapter;
        }

        public List<Comment> GetCommentsByUserId(int id)
        {
            List<Comment> comments;

            try
            {
                comments = _comments.Where(c => c.Commenter.ID == id).ToList();
            }
            catch(InvalidOperationException)
            {
                return null;
            }

            return comments;
        }

        public Rating GetRatingByUserId(int id)
        {
            Rating rating;

            try
            {
                rating = _ratings.FirstOrDefault(r => r.Rater.ID == id);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return rating;
        }

    }
}
