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
        public async Task RaceRepoAddUser()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            User author = new User(1, "Caleb", "Password");

            int id = 1;
            int authorId = 1;
            string title = "My Race";
            string type = "Timed";
            float timeLimit = 1000;
            int stepLimit = 4;
            string start = "https://en.wikipedia.org/wiki/Elvis_Presley";
            string end = "https://en.wikipedia.org/wiki/Russia";

            Race insertedRace = new Race(id, authorId, title, type, timeLimit, stepLimit, start, end );

            var userRepo = new UserRepository(context);
            await userRepo.AddUser(author);
            var repo = new RaceRepository(context);

            // act
            await repo.AddRace(insertedRace);

            // assert
            var compare = context.Races.Local.Single(x => x.Id == 1);
            Assert.Equal(insertedRace.Id, compare.Id);
            Assert.Equal(insertedRace.AuthorId, compare.AuthorId);
            Assert.Equal(insertedRace.RaceTitle, compare.Title);
            Assert.Equal(insertedRace.RaceType, compare.Type);
            Assert.Equal(insertedRace.TimeLimit, compare.TimeLimit);
            Assert.Equal(insertedRace.StepLimit, compare.StepLimit);
            Assert.Equal(insertedRace.StartPage, compare.StartPage);
            Assert.Equal(insertedRace.EndPage, compare.EndPage);
        }

    }
}
