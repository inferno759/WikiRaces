using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Library;
using Library.Model;

namespace Test
{
    public class LeaderBoardLineTest
    {
        [Fact]
        public void LeaderBoardLineConstructorPassed()
        {
            int id = 1;
            int score = 5;
            float timeElapsed = 10;
            int stepsTaken = 6;
            DateTime leaderboardDateTime = new DateTime(2021, 10, 31, 14, 5, 20);
            
            List<PathStep> paths = new List<PathStep>();
            paths.Add(new PathStep() 
            {
                CurrentPage = "https://en.wikipedia.org/wiki/O_Captain!_My_Captain!",
                TimeSpent = 5, 
                StepNumber = 3
            });
            List<PathStep> testPaths = new List<PathStep>();
            testPaths.Add(new PathStep()
            {
                CurrentPage = "https://en.wikipedia.org/wiki/O_Captain!_My_Captain!",
                TimeSpent = 5,
                StepNumber = 3
            });

            DateTime testDate1 = new DateTime(2021, 10, 31, 14, 5, 20);

            LeaderboardLine leaderboardLine = new LeaderboardLine(id, score, timeElapsed,
                stepsTaken, leaderboardDateTime, paths);

            Assert.Equal(1, leaderboardLine.Id);
            Assert.Equal(5, leaderboardLine.Score);
            Assert.Equal(10, leaderboardLine.TimeElapsed);
            Assert.Equal(6, leaderboardLine.StepsTaken);
            Assert.Equal(testDate1, leaderboardLine.LeaderboardDateTime);
            Assert.Equal(testPaths[0], leaderboardLine.Path[0]);

        }

        [Fact]
        public void LeaderBoardScoreNegative()
        {
            int testScore = -3;

            LeaderboardLine leaderboardLine = new LeaderboardLine();

            Assert.Throws<ArgumentOutOfRangeException>(() => leaderboardLine.Score = testScore);
        }
        [Fact]
        public void LeaderBoardTimeElapsedTooLow()
        {
            int testTimeElapsed = 0;

            LeaderboardLine leaderboardLine = new LeaderboardLine();

            Assert.Throws<ArgumentOutOfRangeException>(() => leaderboardLine.TimeElapsed = testTimeElapsed);
        }
        [Fact]
        public void LeaderBoardStepsTakenTooLow()
        {
            int testStepsTaken = 0;

            LeaderboardLine leaderboardLine = new LeaderboardLine();

            Assert.Throws<ArgumentOutOfRangeException>(() => leaderboardLine.StepsTaken = testStepsTaken);
        }
    }
}
