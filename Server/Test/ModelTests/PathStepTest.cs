using System;
using Xunit;
using Library;
using Library.Model;


namespace Test
{
    public class PathStepTest
    {
        [Fact]
        public void PathStepConstructorPassed()
        {
            string page = "https://en.wikipedia.org/wiki/Elvis_Presley";
            float time = 12345;
            int stepnumber = 2;

            PathStep pathstep = new PathStep(page, time, stepnumber);

            Assert.Equal("https://en.wikipedia.org/wiki/Elvis_Presley", pathstep.CurrentPage);
            Assert.Equal(12345, pathstep.TimeSpent);
            Assert.Equal(2, pathstep.StepNumber);
        }

        [Fact]
        public void PathStepInvalidCurrentPage()
        {
            string page = "https://www.google.com";

            PathStep pathstep = new PathStep();

            Assert.Throws<ArgumentException>(() => pathstep.CurrentPage = page);
        }

        [Fact]
        public void PathStepTimeSpentInvalid()
        {
            float time = -1;

            PathStep pathstep = new PathStep();

            Assert.Throws<ArgumentException>(() => pathstep.TimeSpent = time);
        }

        [Fact]
        public void PathStepStepNumberInvalid()
        {
            int stepnumber = 0;

            PathStep pathstep = new PathStep();

            Assert.Throws<ArgumentException>(() => pathstep.StepNumber = stepnumber);
        }
    }
}
