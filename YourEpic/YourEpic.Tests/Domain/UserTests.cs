using System;
using System.Collections.Generic;
using Xunit;
using YourEpic.Domain.Models;

namespace YourEpic.Tests.Domain
{
    public class UserTests
    {
        readonly User user = new User(0, "Tester", "Test@test.com", "password", new Role(0, "Publisher"), new List<Epic>());

        [Fact]
        public void GetUsersEpicByID()
        {
            Epic testEpic = new Epic(0, "Test Title", user, DateTime.UtcNow, new List<Chapter>(), new List<Comment>(), new List<Rating>());
            user.Epics.Add(testEpic);

            Assert.True(user.GetEpicById(0) == testEpic, $"The test epic should have an id of {testEpic.ID}");
        }

        [Fact]
        public void GetUsersEpicByTitle()
        {
            Epic testEpic = new Epic(0, "Test Title", user, DateTime.UtcNow, new List<Chapter>(), new List<Comment>(), new List<Rating>());
            user.Epics.Add(testEpic);

            Assert.True(user.GetEpicByTitle("Test Title") == testEpic, $"The test epic should have a title of {testEpic.Title}");
        }
    }
}
