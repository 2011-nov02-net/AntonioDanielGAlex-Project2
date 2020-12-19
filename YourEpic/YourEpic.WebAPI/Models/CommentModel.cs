using System;
namespace YourEpic.WebAPI.Models
{
    public class CommentModel
    {
        public int ID { get; set;}
        public string CommenterName { get; set; }
        public int CommenterID { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateOfComment { get; set; }
        public int ReplyToComment { get; set; }
    }
}
