using System;
namespace YourEpic.WebAPI.Models
{
    public class ChapterModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set;}
        public string Text { get; set;}
        public int EpicID { get; set; }
    }
}
