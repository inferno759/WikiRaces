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
    public class PathStepRepositoryTests
    {
        [Fact]
        public async Task PathStepRepoAddPathStep()
        {
            using var contextFactory = new WikiRaceContextFactory();
            using var context = contextFactory.CreateContext();

            string currentPage = "https://en.wikipedia.org/wiki/Elvis_Presley";
            float timeSpent = 10;
            int stepNumber = 1;
            PathStep insertedPath = new PathStep(currentPage, timeSpent, stepNumber);

            var repo = new PathStepRepository(context);

            await repo.AddPathStep(insertedPath);

            var compare = context.PathSteps.Local.Single(x => x.StepNumber == 1);
            Assert.Equal(insertedPath.CurrentPage, compare.CurrentPage);
            Assert.Equal(insertedPath.TimeSpent, compare.TimeSpent);
            Assert.Equal(insertedPath.StepNumber, compare.StepNumber);
        }
    }
}



