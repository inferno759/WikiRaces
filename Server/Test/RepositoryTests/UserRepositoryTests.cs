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
    }
}
