using System;

namespace YourEpic.Domain.Models
{
    public class Chapter
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Epic ChapterEpic { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }

    }
}
