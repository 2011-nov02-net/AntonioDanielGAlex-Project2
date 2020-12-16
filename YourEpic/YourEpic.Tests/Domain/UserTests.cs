using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using YourEpic.Domain.Models;

namespace YourEpic.Tests.Domain
{
    public class UserTests
    {
        readonly User user = new User
        {
            ID = 0,
            Name = "Tester",
            Epics = new[] { new Epic { ID = 0, Title = "Test Title", Date = DateTime.UtcNow } }
        };

        [Fact]
        public void GetUsersEpicByID()
        {
            Assert.True(user.GetEpicById(0).Title == "Test Title", $"The test epic should have an id of 0");
        }

        [Fact]
        public void GetUsersEpicByTitle()
        {
            Assert.True(user.GetEpicByTitle("Test Title").ID == 0, $"The test epic should have a title of [Test Title]");
        }
    }
}
