using System;
using System.Collections.Generic;
using System.Linq;

namespace YourEpic.Domain.Models
{
    public class Epic
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public User Writer { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Chapter> Chapters { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public int ChapterCount => Chapters.Count();
        public int CommentCount => Comments.Count();
        public int RatingCount => Ratings.Count();
        public double AverageRating => Ratings.Average(r => r.RatingNumber);

        public Chapter GetChapterById(int id)
        {
            Chapter chapter = Chapters.FirstOrDefault(c => c.ID == id);

            return chapter;
        }

        public Chapter GetChapterByTitle(string title)
        {
            Chapter chapter = Chapters.FirstOrDefault(c => c.Title == title);

            return chapter;
        }

        public List<Comment> GetCommentsByUserId(int id)
        {
            List<Comment> comments;

            try
            {
                comments = Comments.Where(c => c.Commenter.ID == id).ToList();
            }
            catch (InvalidOperationException)
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
                rating = Ratings.FirstOrDefault(r => r.Rater.ID == id);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return rating;
        }

    }
}
