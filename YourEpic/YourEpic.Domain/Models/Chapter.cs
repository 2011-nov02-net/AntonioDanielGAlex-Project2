using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Models
{
    public class Chapter
    {
        private readonly int _id;
        private readonly string _title;
        private readonly Epic _chapterEpic;
        private readonly DateTime _date;
        private readonly string _text;

        public Chapter(int id, string title, Epic epic, DateTime date, string text)
        {
            _id = id;
            _title = title;
            _chapterEpic = epic;
            _date = date;
            _text = text;
        }

        public Chapter(string title, Epic epic, DateTime date, string text)
        {
            _title = title;
            _chapterEpic = epic;
            _date = date;
            _text = text;
        }

        public int ID => _id;
        public string Title => _title;
        public Epic ChapterEpic => _chapterEpic;
        public DateTime Date => _date;
        public string Text => _text;


    }
}
