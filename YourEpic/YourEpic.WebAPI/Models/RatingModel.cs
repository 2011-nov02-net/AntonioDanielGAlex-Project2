using System;
namespace YourEpic.WebAPI.Models
{
    public class RatingModel
    {
        public int ID { get; set; }
        public UserModel Rater { get; set; }
        public double RatingNumber { get; set; }
    }
}
