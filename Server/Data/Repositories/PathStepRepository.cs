using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Model;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories
{
    public class PathStepRepository : IPathStepRepository
    {
        private readonly Entities.Project2Context _context;

        public PathStepRepository(Entities.Project2Context context)
        {
            _context = context;
        }

        public async Task AddPathStep(PathStep pathStep)
        {
            Entities.PathStep newPathStep = new Entities.PathStep
            {
                CurrentPage = pathStep.CurrentPage,
                TimeSpent = pathStep.TimeSpent,
                StepNumber = pathStep.StepNumber
            };
            await _context.AddAsync(newPathStep);
            await _context.SaveChangesAsync();
        }

        
        public Task DeletePathStep(PathStep pathStep)
        {
            throw new NotImplementedException();
        }
        

        public Task<PathStep> GetPathStepByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PathStep>> GetPathSteps()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePathStep(PathStep pathStep)
        {
            throw new NotImplementedException();
        }
    }
}
