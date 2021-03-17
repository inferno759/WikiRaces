using System;
using Xunit;
using Library;
using Library.Model;


namespace Tests
{
    public class UserTest
    {
        [Fact]
        public void UserConstructedPassed()
        {

            User user = new User();

            Assert.NotNull(user);
        }
    }
}
