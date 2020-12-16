using System;
using System.Collections.Generic;
using Xunit;
using YourEpic.Domain.Models;

namespace YourEpic.Tests.Domain
{
    public class EpicTests
    {
        static readonly User Test1 = new User { ID = 0 };
        static readonly User Test2 = new User { ID = 02 };
        readonly Epic TestEpic = new Epic
        {
            ID = 0,
            Chapters = new[] { new Chapter { ID = 0, Title = "Chapter 1" }, new Chapter { ID = 1, Title = "Chapter 2" } },
            Comments = new[] { new Comment { ID = 0, Commenter = Test1 }, new Comment { ID = 1, Commenter = Test2 } },
            Ratings = new[] { new Rating { Rater = Test1, ID = 0, RatingNumber = 5 }, new Rating { Rater = Test2, ID = 0, RatingNumber = 1 } },
            Title = "New Epic"
        };

        [Fact]
        public void GetEpicsChapterByID()
        {
            Assert.True(TestEpic.GetChapterById(0).Title == "Chapter 1", "The chapters should be the same");
        }

        [Fact]
        public void GetEpicsChapterByChapterTitle()
        {

            Assert.True(TestEpic.GetChapterByTitle("Chapter 1").ID == 0, "The chapters should be the same");
        }

        [Fact]
        public void GetCommentsByUserID()
        {
            Assert.True(TestEpic.GetCommentsByUserId(0).Count == 1, "There should only exist 1 comment by user id 0");
        }

        [Fact]
        public void GetRatingsByUserID()
        {

            Assert.True(TestEpic.GetRatingByUserId(0).RatingNumber == 5, "There should only exist 1 comment by user id 0");
        }
    }
}
