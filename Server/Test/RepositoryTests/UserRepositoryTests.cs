using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Library;
using System.Threading.Tasks;
using Library.Model;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test.RepositoryTests
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task UserRepoAddUser()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            int id = 1;
            string username = "tdunbar123";
            string password = "Password123!";
            User insertedUser = new User(id, username, password);

            var repo = new UserRepository(context);

            // act
            await repo.AddUser(insertedUser);

            // assert
            var compare = context.Users.Local.Single(x => x.Id == 1);
            Assert.Equal(insertedUser.Id, compare.Id);
            Assert.Equal(insertedUser.Username, compare.Username);
            Assert.Equal(insertedUser.Password, compare.Password);
        }

        [Fact]
        public async Task UserRepoGetUserByIDDoesNotExist()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            int id = 1;
            string username = "tdunbar123";
            string password = "Password123!";
            User insertedUser = new User(id, username, password);

            var repo = new UserRepository(context);

            // act
            await repo.AddUser(insertedUser);
            // assert
            await Assert.ThrowsAsync<ArgumentException>(() => repo.GetUserByID(2));
        }

        [Fact]
        public async Task UserRepoGetUserByID()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            int id = 1;
            string username = "tdunbar123";
            string password = "Password123!";
            User insertedUser = new User(id, username, password);

            var repo = new UserRepository(context);

            // act
            await repo.AddUser(insertedUser);
            var getUser = await repo.GetUserByID(1);
            // assert
            Assert.Equal(insertedUser.Id, getUser.Id);
            Assert.Equal(insertedUser.Username, getUser.Username);
            Assert.Equal(insertedUser.Password, getUser.Password);
        }

        [Fact]
        public async Task UserRepoGetUserByUsernameDoesNotExist()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            int id = 1;
            string username = "tdunbar123";
            string password = "Password123!";
            User insertedUser = new User(id, username, password);

            var repo = new UserRepository(context);

            // act
            await repo.AddUser(insertedUser);
            // assert
            await Assert.ThrowsAsync<ArgumentException>(() => repo.GetUserByUsername("tdunbar"));
        }

        [Fact]
        public async Task UserRepoGetUserByUsername()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            int id = 1;
            string username = "tdunbar123";
            string password = "Password123!";
            User insertedUser = new User(id, username, password);

            var repo = new UserRepository(context);

            // act
            await repo.AddUser(insertedUser);
            var getUser = await repo.GetUserByUsername("tdunbar123");
            // assert
            Assert.Equal(insertedUser.Id, getUser.Id);
            Assert.Equal(insertedUser.Username, getUser.Username);
            Assert.Equal(insertedUser.Password, getUser.Password);
        }

        [Fact]
        public async Task UserRepoGetAllUsers()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            int id = 1;
            string username = "tdunbar123";
            string password = "Password123!";
            User insertedUser = new User(id, username, password);
            User secondUser = new User(2, "secondUser", "newPassword!");

            var repo = new UserRepository(context);

            // act
            await repo.AddUser(insertedUser);
            await repo.AddUser(secondUser);
            var users = await repo.GetAllUsers();
            // assert
            Assert.Equal(insertedUser.Id, users[0].Id);
            Assert.Equal(insertedUser.Username, users[0].Username);
            Assert.Equal(insertedUser.Password, users[0].Password);
            Assert.Equal(secondUser.Id, users[1].Id);
            Assert.Equal(secondUser.Username, users[1].Username);
            Assert.Equal(secondUser.Password, users[1].Password);
        }

        [Fact]
        public async Task UserRepoUpdateUserFriends()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            int id = 1;
            string username = "tdunbar123";
            string password = "Password123!";
            User insertedUser = new User(id, username, password);
            User friend = new User(2, "FriendName", "FriendPassword");

            var repo = new UserRepository(context);

            // act
            await repo.AddUser(insertedUser);
            await repo.AddUser(friend);
            insertedUser.AddFriend(friend);
            await repo.UpdateUser(insertedUser);
            var getUser = await repo.GetUserByID(1);
            // assert
            Assert.Equal(2, getUser.Friends[0]);
        }
    }
}
