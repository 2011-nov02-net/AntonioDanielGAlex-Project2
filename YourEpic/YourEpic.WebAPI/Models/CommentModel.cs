using System;
namespace YourEpic.WebAPI.Models
{
    public class CommentModel
    {
        public int ID { get; set;}
        public string CommenterName { get; set; }
        public string CommentCount { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}
