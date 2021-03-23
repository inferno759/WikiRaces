using System;
using Xunit;
using Library;
using Library.Model;

namespace Test
{
    public class RaceTest
    {
        [Fact]
        public void RaceTestConstructor()
        {
            int id = 1;
            int authorId = 2;
            string title = "My Race";
            string type = "Timed";
            float timeLimit = 1000;
            int stepLimit = 4;
            string start = "/wiki/Elvis_Presley";
            string end = "/wiki/Russia";

            Race race = new Race(id, authorId, title, type, timeLimit, stepLimit, start, end);

            Assert.Equal(1, race.Id);
            Assert.Equal(2, race.AuthorId);
            Assert.Equal("My Race", race.RaceTitle);
            Assert.Equal("Timed", race.RaceType);
            Assert.Equal(1000, race.TimeLimit);
            Assert.Equal(4, race.StepLimit);
            Assert.Equal("/wiki/Elvis_Presley", race.StartPage);
            Assert.Equal("/wiki/Russia", race.EndPage);
        }

        [Fact]
        public void RaceTitleTooShort()
        {
            string title = "aa";

            Race race = new Race();

            Assert.Throws<ArgumentException>(() => race.RaceTitle = title);
        }

        [Fact]
        public void RaceTitleTooLong()
        {
            string title = "123456789012345678901234567890123456789012345678901234567890123456789012345678901"; // 81 chars

            Race race = new Race();

            Assert.Throws<ArgumentException>(() => race.RaceTitle = title);
        }

        [Fact]
        public void RaceTitleContainsSymbols()
        {
            string title = "asdf123!";

            Race race = new Race();

            Assert.Throws<ArgumentException>(() => race.RaceTitle = title);
        }

        [Fact]
        public void RaceTypeTooShort()
        {
            string type = "aa";

            Race race = new Race();

            Assert.Throws<ArgumentException>(() => race.RaceType = type);
        }

        [Fact]
        public void RaceTypeTooLong()
        {
            string type = "12345678901234567890123456789012345678901"; // 41 chars

            Race race = new Race();

            Assert.Throws<ArgumentException>(() => race.RaceType = type);
        }

        [Fact]
        public void RaceInvalidTimeLimit()
        {
            float timeLimit = -1;

            Race race = new Race();

            Assert.Throws<ArgumentOutOfRangeException>(() => race.TimeLimit = timeLimit);
        }

        [Fact]
        public void RaceInvalidStepLimit()
        {
            int stepLimit = -1;

            Race race = new Race();

            Assert.Throws<ArgumentOutOfRangeException>(() => race.StepLimit = stepLimit);
        }

        [Fact]
        public void RaceInvalidStartPage()
        {
            string startPage = "google.com";

            Race race = new Race();

            Assert.Throws<ArgumentException>(() => race.StartPage = startPage);
        }

        [Fact]
        public void RaceInvalidEndPage()
        {
            string endPage = "google.com";

            Race race = new Race();

            Assert.Throws<ArgumentException>(() => race.EndPage = endPage);
        }
    }
}
