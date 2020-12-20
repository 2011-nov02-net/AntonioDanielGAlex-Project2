using System;
using System.Collections.Generic;
using System.Linq;

namespace YourEpic.Domain.Models
{
    public class Epic
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Concept { get; set; }
        public User Writer { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateCompleted { get; set; }
        public IEnumerable<Chapter> Chapters { get; set; } = new List<Chapter>();
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public double GetAverageRating()
        {
            if (Ratings.Count() == 0) { return 0; }
            return Ratings.Average(r => r.RatingNumber);
        }

        public Rating GetRatingByUserID(int userID)
        {
            return Ratings.First(r => r.Rater.ID == userID);
        }

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

        public int GetChapterCount()
        {
            return Chapters.ToList().Count();
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
                return new List<Comment>();
            }

            return comments;
        }

        public int GetCommentCount()
        {
            return Comments.ToList().Count();
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
                return new Rating();
            }

            return rating;
        }

        public int GetRatingCount()
        {
            return Ratings.ToList().Count();
        }

    }
}
