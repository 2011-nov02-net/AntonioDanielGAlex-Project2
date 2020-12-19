using System;
using System.Collections.Generic;

namespace YourEpic.WebAPI.Models
{
    public class EpicModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Concept { get; set; }
        public UserModel Author { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public int ChapterCount { get; set; }
        public int CommentCount { get; set; }
        public int RatingCount { get; set; }
        public double AverageRating { get; set; }
    }
}
