using System;
namespace YourEpic.WebAPI.Models
{
    public class RatingModel
    {
        public int ID { get; set; }
        public int RaterID { get; set; }
        public int EpicID { get; set; }
        public string Rater { get; set; }
        public int RatingNumber { get; set; }
    }
}
