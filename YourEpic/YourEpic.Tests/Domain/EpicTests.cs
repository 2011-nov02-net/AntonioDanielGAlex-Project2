using System;
using System.Collections.Generic;
using Xunit;
using YourEpic.Domain.Models;

namespace YourEpic.Tests.Domain
{
    public class EpicTests
    {
        readonly User user = new User(0, "Tester", "Test@test.com", "password", new Role(0, "Reader"), new List<Epic>());
        readonly Epic TestEpic = new Epic(0, "Epic Test",
            new User(0, "Tester", "Test@test.com", "password",
                new Role(0, "Reader"),
                new List<Epic>()), DateTime.Now,
            new List<Chapter>(),
            new List<Comment>(),
            new List<Rating>());

        [Fact]
        public void GetEpicsChapterByID()
        {
            Chapter chapter = new Chapter(0, "Test Chapter", TestEpic, DateTime.Now, "This is the content for the epic");

            TestEpic.Chapters.Add(chapter);

            Assert.True(TestEpic.GetChapterById(0) == chapter, "The chapters should be the same");
        }

        [Fact]
        public void GetEpicsChapterByChapterTitle()
        {
            Chapter chapter = new Chapter(0, "Test Chapter", TestEpic, DateTime.Now, "This is the content for the epic");

            TestEpic.Chapters.Add(chapter);

            Assert.True(TestEpic.GetChapterByTitle("Test Chapter") == chapter, "The chapters should be the same");
        }

        [Fact]
        public void GetCommentsByUserID()
        {
            Comment comment = new Comment(0, user, TestEpic, "This is the comment.", DateTime.UtcNow);
            Comment comment2 = new Comment(1, new User(1, "Tester2", "Test@test.com", "password",
                new Role(0, "Reader"), new List<Epic>()), TestEpic, "This is the comment.", DateTime.UtcNow);

            TestEpic.Comments.Add(comment);
            TestEpic.Comments.Add(comment2);

            Assert.True(TestEpic.GetCommentsByUserId(0).Count == 1, "There should only exist 1 comment by user id 0");
        }

        [Fact]
        public void GetRatingsByUserID()
        {
            Rating rating1 = new Rating(0, user, TestEpic, 5);
            Rating rating2 = new Rating(1, new User(1, "Tester2", "Test@test.com", "password",
                new Role(0, "Reader"), new List<Epic>()), TestEpic, 1);

            TestEpic.Ratings.Add(rating1);
            TestEpic.Ratings.Add(rating1);

            Assert.True(TestEpic.GetRatingByUserId(0) == rating1, "There should only exist 1 comment by user id 0");
        }
    }
}
