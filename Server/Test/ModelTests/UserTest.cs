using System;
using Xunit;
using Library;
using Library.Model;


namespace Test
{
    public class UserTest
    {
        [Fact]
        public void UserConstructorPassed()
        {
            int id = 1;
            string username = "tdunbar";
            string password = "password123!";

            User user = new User(id, username, password);

            Assert.Equal(1, user.Id);
            Assert.Equal("tdunbar", user.Username);
            Assert.Equal("password123!", user.Password);
        }

        [Fact]
        public void UserUsernameTooShort()
        {
            string username = "td";

            User user = new User();

            Assert.Throws<ArgumentException>(() => user.Username = username);
        }

        [Fact]
        public void UserUsernameTooLong()
        {
            string username = "12345678901234567890123456"; // 26 chars

            User user = new User();

            Assert.Throws<ArgumentException>(() => user.Username = username);
        }

        [Fact]
        public void UserUsernameNotAlphaNumeric()
        {
            string username = "tdunb@r";

            User user = new User();

            Assert.Throws<ArgumentException>(() => user.Username = username);
        }

        [Fact]
        public void UserPasswordTooShort()
        {
            string password = "td";

            User user = new User();

            Assert.Throws<ArgumentException>(() => user.Password = password);
        }

        [Fact]
        public void UserPasswordTooLong()
        {
            string password = "12345678901234567890123456"; // 26 chars

            User user = new User();

            Assert.Throws<ArgumentException>(() => user.Password = password);
        }

        [Fact]
        public void UserPasswordContainsWhitespace()
        {
            string password = "tdunb r";

            User user = new User();

            Assert.Throws<ArgumentException>(() => user.Password = password);
        }

        [Fact]
        public void UserAddFriendSuccess()
        {
            int id = 1;
            string username = "tdunbar";
            string password = "password123!";
            int friendId = 2;
            string friendUsername = "brandonF";
            string friendPassword = "!321drowssap";

            User user = new User(id, username, password);
            User friend = new User(friendId, friendUsername, friendPassword);
            user.AddFriend(friend);

            Assert.Contains<int?>(friend.Id, user.Friends);
        }

        [Fact]
        public void UserAddFriendFails()
        {
            int id = 1;
            string username = "tdunbar";
            string password = "password123!";
            int friendId = 2;
            string friendUsername = "brandonF";
            string friendPassword = "!321drowssap";

            User user = new User(id, username, password);
            User friend = new User(friendId, friendUsername, friendPassword);
            user.AddFriend(friend);

            Assert.Throws<ArgumentException>(() => user.AddFriend(friend));
        }

        [Fact]
        public void UserDeleteFriendSuccess()
        {
            int id = 1;
            string username = "tdunbar";
            string password = "password123!";
            int friendId = 2;
            string friendUsername = "brandonF";
            string friendPassword = "!321drowssap";

            User user = new User(id, username, password);
            User friend = new User(friendId, friendUsername, friendPassword);
            user.AddFriend(friend);
            user.DeleteFriend(friend);

            Assert.DoesNotContain<int?>(friend.Id, user.Friends);
        }

        [Fact]
        public void UserDeleteFriendFails()
        {
            int id = 1;
            string username = "tdunbar";
            string password = "password123!";
            int friendId = 2;
            string friendUsername = "brandonF";
            string friendPassword = "!321drowssap";

            User user = new User(id, username, password);
            User friend = new User(friendId, friendUsername, friendPassword);

            Assert.Throws<ArgumentException>(() => user.DeleteFriend(friend));
        }
    }
}
