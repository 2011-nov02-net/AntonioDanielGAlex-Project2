namespace YourEpic.Domain.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public User Rater { get; set; }
        public Epic RatingEpic { get; set; }
        public int RatingNumber { get; set; }
    }
}
