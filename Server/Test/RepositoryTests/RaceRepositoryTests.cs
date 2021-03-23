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
    public class RaceRepositoryTests
    {
        [Fact]
        public async Task RaceRepoAddRace()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            User author = new User(1, "Caleb", "Password");

            int id = 0;
            int authorId = 1;
            string title = "My Race";
            string type = "Timed";
            float timeLimit = 1000;
            int stepLimit = 4;
            string start = "/wiki/Elvis_Presley";
            string end = "/wiki/Russia";

            Race insertedRace = new Race(id, authorId, title, type, timeLimit, stepLimit, start, end );

            var userRepo = new UserRepository(context);
            await userRepo.AddUser(author);
            var repo = new RaceRepository(context);

            // act
            await repo.AddRace(insertedRace);

            // assert
            var compare = context.Races.Local.Single(x => x.Id == 1);
            Assert.Equal(insertedRace.AuthorId, compare.AuthorId);
            Assert.Equal(insertedRace.RaceTitle, compare.Title);
            Assert.Equal(insertedRace.RaceType, compare.Type);
            Assert.Equal(insertedRace.TimeLimit, compare.TimeLimit);
            Assert.Equal(insertedRace.StepLimit, compare.StepLimit);
            Assert.Equal(insertedRace.StartPage, compare.StartPage);
            Assert.Equal(insertedRace.EndPage, compare.EndPage);
        }

        [Fact]
        public async Task RaceRepoGetRaceByID()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            User author = new User(1, "Caleb", "Password");

            int id = 0;
            int authorId = 1;
            string title = "My Race";
            string type = "Timed";
            float timeLimit = 1000;
            int stepLimit = 4;
            string start = "/wiki/Elvis_Presley";
            string end = "/wiki/Russia";

            Race insertedRace = new Race(id, authorId, title, type, timeLimit, stepLimit, start, end);

            var userRepo = new UserRepository(context);
            await userRepo.AddUser(author);
            var repo = new RaceRepository(context);

            // act
            await repo.AddRace(insertedRace);

            // assert
            var compare = await repo.GetRaceByID(1);
            Assert.Equal(insertedRace.AuthorId, compare.AuthorId);
            Assert.Equal(insertedRace.RaceTitle, compare.RaceTitle);
            Assert.Equal(insertedRace.RaceType, compare.RaceType);
            Assert.Equal(insertedRace.TimeLimit, compare.TimeLimit);
            Assert.Equal(insertedRace.StepLimit, compare.StepLimit);
            Assert.Equal(insertedRace.StartPage, compare.StartPage);
            Assert.Equal(insertedRace.EndPage, compare.EndPage);
        }

        [Fact]
        public async Task RaceRepoGetRaceByTitle()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            User author = new User(1, "Caleb", "Password");

            int id = 0;
            int authorId = 1;
            string title = "My Race";
            string type = "Timed";
            float timeLimit = 1000;
            int stepLimit = 4;
            string start = "/wiki/Elvis_Presley";
            string end = "/wiki/Russia";

            Race insertedRace = new Race(id, authorId, title, type, timeLimit, stepLimit, start, end);

            var userRepo = new UserRepository(context);
            await userRepo.AddUser(author);
            var repo = new RaceRepository(context);

            // act
            await repo.AddRace(insertedRace);

            // assert
            var compare = await repo.GetRacesByTitle("My Race");
            Assert.Equal(insertedRace.AuthorId, compare[0].AuthorId);
            Assert.Equal(insertedRace.RaceTitle, compare[0].RaceTitle);
            Assert.Equal(insertedRace.RaceType, compare[0].RaceType);
            Assert.Equal(insertedRace.TimeLimit, compare[0].TimeLimit);
            Assert.Equal(insertedRace.StepLimit, compare[0].StepLimit);
            Assert.Equal(insertedRace.StartPage, compare[0].StartPage);
            Assert.Equal(insertedRace.EndPage, compare[0].EndPage);
        }

    }
}
