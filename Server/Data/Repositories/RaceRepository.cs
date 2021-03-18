using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories
{
    class RaceRepository : IRaceRepository
    {
        private readonly Entities.Project2Context _context;

        public RaceRepository(Entities.Project2Context context)
        {
            _context = context;
        }

        public async Task AddRace(Race race)
        {
            Entities.Race newRace = new Entities.Race
            {
                Id = race.Id,
                Title = race.RaceTitle,
                Type = race.RaceType,
                TimeLimit = race.TimeLimit,
                StepLimit = race.StepLimit,
                StartPage = race.StartPage,
                EndPage = race.EndPage,
                AuthorId = race.AuthorId   // user foreign key
            };
            await _context.AddAsync(newRace);
            await _context.SaveChangesAsync();
        }

        public Task DeleteRace(Race race)
        {
            throw new NotImplementedException();
        }

        public Task<Race> GetRaceByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Race>> GetRaces()
        {
            List<Race> raceList = new List<Race>();
            var races = await _context.Races.ToListAsync();
            
            if(races != null)
            {
                foreach(var onerace in races)
                {
                    raceList.Add(new Race
                    {
                        Id = onerace.Id,
                        RaceTitle = onerace.Title,
                        RaceType = onerace.Type,
                        TimeLimit = (float)onerace.TimeLimit,
                        StepLimit = (int)onerace.StepLimit,
                        StartPage = onerace.StartPage,
                        EndPage = onerace.EndPage,
                        AuthorId = (int)onerace.AuthorId
                    });
                }
            }
            else 
            {
                throw new ArgumentException("No Races to get");
            }
            return raceList;
        }
        

        public Task<IEnumerable<Race>> GetRacesByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRace(Race race)
        {
            throw new NotImplementedException();
        }
    }
}
