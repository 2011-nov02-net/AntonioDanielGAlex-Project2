namespace YourEpic.Domain.Models
{
    public class Rating
    {
        private readonly int _id;
        private readonly User _rater;
        private readonly Epic _ratingEpic;
        private readonly int _ratingNumber;

        public Rating(int id, User user, Epic epic, int number)
        {
            _id = id;
            _rater = user;
            _ratingEpic = epic;
            _ratingNumber = number;
        }

        public Rating(User user, Epic epic, int number)
        {
            _rater = user;
            _ratingEpic = epic;
            _ratingNumber = number;
        }

        public int ID => _id;
        public User Rater => _rater;
        public Epic RatingEpic => _ratingEpic;
        public int RatingNumber => _ratingNumber;
    }
}
