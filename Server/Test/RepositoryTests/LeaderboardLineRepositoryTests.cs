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
    public class LeaderboardLineRepositoryTests
    {
        [Fact]
        public async Task AddLeaderBoardLine()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            DateTime time = DateTime.Now;
            List<PathStep> path = new List<PathStep>();
            path.Add(new PathStep("https://en.wikipedia.org/wiki/MARCKSL1", (float)25.2, 1));
            path.Add(new PathStep("https://en.wikipedia.org/wiki/Calmodulin", (float)50.3, 2));
            User racer = new User(1, "Trevor", "PAssword");
            LeaderboardLine newLine = new LeaderboardLine(1, 1, 1, 1000, (float)1001.3, 2,
            time, path, racer);

            
            Race race = new Race(1, 1, "trevsRace", "Timed", 10000, 4, "https://en.wikipedia.org/wiki/MARCKSL1", "https://en.wikipedia.org/wiki/Calmodulin");
            var userRepo = new UserRepository(context);
            await userRepo.AddUser(racer);
            var raceRepo = new RaceRepository(context);
            await raceRepo.AddRace(race);
            var leaderboardRepo = new LeaderboardLineRepository(context);
            await leaderboardRepo.AddLeaderboardLine(newLine);

            var compare = context.LeaderboardLines.Local.Single(x => x.Id == 1);
            Assert.Equal(1, compare.Id);
            Assert.Equal(1, compare.RaceId);
            Assert.Equal(1, compare.UserId);
            Assert.Equal(1000, compare.Score);
            Assert.Equal((int)1001.3, (int)compare.TimeElapsed);
            Assert.Equal(2, compare.StepsTaken);
            Assert.Equal(time, compare.CompletionDate);
            Assert.NotEmpty(compare.PathSteps);
        }

        [Fact]
        public async Task GetLeaderBoardLineById()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            DateTime time = DateTime.Now;
            List<PathStep> path = new List<PathStep>();
            path.Add(new PathStep("https://en.wikipedia.org/wiki/MARCKSL1", (float)25.2, 1));
            path.Add(new PathStep("https://en.wikipedia.org/wiki/Calmodulin", (float)50.3, 2));
            User racer = new User(1, "Trevor", "PAssword");
            LeaderboardLine newLine = new LeaderboardLine(1, 1, 1, 1000, (float)1001.3, 2,
            time, path, racer);

            
            Race race = new Race(1, 1, "trevsRace", "Timed", 10000, 4, "https://en.wikipedia.org/wiki/MARCKSL1", "https://en.wikipedia.org/wiki/Calmodulin");
            var userRepo = new UserRepository(context);
            await userRepo.AddUser(racer);
            var raceRepo = new RaceRepository(context);
            await raceRepo.AddRace(race);
            var leaderboardRepo = new LeaderboardLineRepository(context);
            await leaderboardRepo.AddLeaderboardLine(newLine);

            var compare = await leaderboardRepo.GetLeaderboardLineByID(1);
            Assert.Equal(1, compare.Id);
            Assert.Equal(1, compare.RaceId);
            Assert.Equal(1, compare.UserId);
            Assert.Equal(1000, compare.Score);
            Assert.Equal((int)1001.3, (int)compare.TimeElapsed);
            Assert.Equal(2, compare.StepsTaken);
            Assert.Equal(time, compare.LeaderboardDateTime);
            Assert.NotEmpty(compare.Path);
            Assert.Equal("Trevor", compare.User.Username);
        }

        [Fact]
        public async Task GetLeaderBoardLineByIdFail()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            DateTime time = DateTime.Now;
            List<PathStep> path = new List<PathStep>();
            path.Add(new PathStep("https://en.wikipedia.org/wiki/MARCKSL1", (float)25.2, 1));
            path.Add(new PathStep("https://en.wikipedia.org/wiki/Calmodulin", (float)50.3, 2));
            User racer = new User(1, "Trevor", "PAssword");
            LeaderboardLine newLine = new LeaderboardLine(1, 1, 1, 1000, (float)1001.3, 2,
            time, path, racer);

            
            Race race = new Race(1, 1, "trevsRace", "Timed", 10000, 4, "https://en.wikipedia.org/wiki/MARCKSL1", "https://en.wikipedia.org/wiki/Calmodulin");
            var userRepo = new UserRepository(context);
            await userRepo.AddUser(racer);
            var raceRepo = new RaceRepository(context);
            await raceRepo.AddRace(race);
            var leaderboardRepo = new LeaderboardLineRepository(context);
            await leaderboardRepo.AddLeaderboardLine(newLine);

            await Assert.ThrowsAsync<ArgumentException>(() => leaderboardRepo.GetLeaderboardLineByID(2));
        }

        [Fact]
        public async Task GetLeaderBoardLinesByRace()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            DateTime time = DateTime.Now;
            List<PathStep> path = new List<PathStep>();
            path.Add(new PathStep("https://en.wikipedia.org/wiki/MARCKSL1", (float)25.2, 1));
            path.Add(new PathStep("https://en.wikipedia.org/wiki/Calmodulin", (float)50.3, 2));
            User racer = new User(1, "Trevor", "PAssword");
            LeaderboardLine newLine = new LeaderboardLine(1, 1, 1, 1000, (float)1001.3, 2,
            time, path, racer);

            
            Race race = new Race(1, 1, "trevsRace", "Timed", 10000, 4, "https://en.wikipedia.org/wiki/MARCKSL1", "https://en.wikipedia.org/wiki/Calmodulin");
            var userRepo = new UserRepository(context);
            await userRepo.AddUser(racer);
            var raceRepo = new RaceRepository(context);
            await raceRepo.AddRace(race);
            var leaderboardRepo = new LeaderboardLineRepository(context);
            await leaderboardRepo.AddLeaderboardLine(newLine);
            race = await raceRepo.GetRaceByID(1);

            var compare = await leaderboardRepo.GetLeaderboardLinesByRace(race.Id);
            var first = compare[0];
            Assert.Equal(1, first.Id);
            Assert.Equal(1, first.RaceId);
            Assert.Equal(1, first.UserId);
            Assert.Equal(1000, first.Score);
            Assert.Equal((int)1001.3, (int)first.TimeElapsed);
            Assert.Equal(2, first.StepsTaken);
            Assert.Equal(time, first.LeaderboardDateTime);
            Assert.NotEmpty(first.Path);
        }

        [Fact]
        public async Task GetLeaderBoardLinesByUser()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            DateTime time = DateTime.Now;
            List<PathStep> path = new List<PathStep>();
            path.Add(new PathStep("https://en.wikipedia.org/wiki/MARCKSL1", (float)25.2, 1));
            path.Add(new PathStep("https://en.wikipedia.org/wiki/Calmodulin", (float)50.3, 2));
            User racer = new User(1, "Trevor", "PAssword");
            LeaderboardLine newLine = new LeaderboardLine(1, 1, 1, 1000, (float)1001.3, 2,
            time, path, racer);

            
            Race race = new Race(1, 1, "trevsRace", "Timed", 10000, 4, "https://en.wikipedia.org/wiki/MARCKSL1", "https://en.wikipedia.org/wiki/Calmodulin");
            var userRepo = new UserRepository(context);
            await userRepo.AddUser(racer);
            var raceRepo = new RaceRepository(context);
            await raceRepo.AddRace(race);
            var leaderboardRepo = new LeaderboardLineRepository(context);
            await leaderboardRepo.AddLeaderboardLine(newLine);
            racer = await userRepo.GetUserByID(1);

            var compare = await leaderboardRepo.GetLeaderboardLinesByUser(racer.Id);
            var first = compare[0];
            Assert.Equal(1, first.Id);
            Assert.Equal(1, first.RaceId);
            Assert.Equal(1, first.UserId);
            Assert.Equal(1000, first.Score);
            Assert.Equal((int)1001.3, (int)first.TimeElapsed);
            Assert.Equal(2, first.StepsTaken);
            Assert.Equal(time, first.LeaderboardDateTime);
            Assert.NotEmpty(first.Path);
        }
    }
}
