using System;
using Xunit;
using Library;


namespace Tests
{
    public class UserTest
    {
        [Fact]
        public void UserConstructedPassed()
        {

            User user = new User(15, "myusername", "mypassword");

            Assert.NotNull(user);
        }
    }
}
