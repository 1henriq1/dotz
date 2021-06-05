using Dotz.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void NewUserShouldHaveBalance()
        {
            var user = new User("", "");
            user.Balance.Should().Be(0);
        }

        [TestMethod]
        public void NewUserShouldHaveId()
        {
            var user = new User("","");
            user.Id.Should().NotBeEmpty();
        }
    }
}
