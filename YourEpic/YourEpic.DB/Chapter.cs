using System;

#nullable disable

namespace YourEpic.DB
{
    public partial class Chapter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EpicId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Text { get; set; }

        public virtual Epic Epic { get; set; }
    }
}
