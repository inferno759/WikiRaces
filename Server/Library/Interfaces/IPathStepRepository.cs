using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Interfaces
{
    public interface IPathStepRepository
    { // Not sure if this will ever be used... implementing it just in case though.
        Task AddPathStep(PathStep pathStep);
        Task<PathStep> GetPathStepByID(int id);
        Task<IEnumerable<PathStep>> GetPathSteps();
        Task UpdatePathStep(PathStep pathStep);
        Task DeletePathStep(PathStep pathStep);
    }
}
