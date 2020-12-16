using System;

namespace YourEpic.Domain.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public User Commenter { get; set; }
        public Epic CommentEpic { get; set; }
        public string CommentContent { get; set; }
        public DateTime Date { get; set; }
    }
}
