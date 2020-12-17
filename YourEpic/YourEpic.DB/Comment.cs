using System;
using System.Collections.Generic;

#nullable disable

namespace YourEpic.DB
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int CommenterId { get; set; }
        public int EpicId { get; set; }
        public string Comment1 { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ReplyToComment { get; set; }

        public virtual User Commenter { get; set; }
        public virtual Epic Epic { get; set; }
    }
}
