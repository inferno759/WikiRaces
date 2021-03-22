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
    public class RaceRepository : IRaceRepository
    {
        private readonly Entities.Project2Context _context;

        public RaceRepository(Entities.Project2Context context)
        {
            _context = context;
        }

        public async Task AddRace(Race race)
        {
            if (race.Id == 0)
            {
                Entities.Race newRace = new Entities.Race
                {
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
        }

        public Task DeleteRace(Race race)
        {
            throw new NotImplementedException();
        }

        public async Task<Race> GetRaceByID(int id)
        {
            Entities.Race query;
            try
            {
                query = await _context.Races.FindAsync(id);
            }
            catch
            {
                throw new ArgumentException("Couldn't find race with that ID");
            }
            return new Race
            {
                Id = query.Id,
                AuthorId = query.AuthorId,
                RaceTitle = query.Title,
                RaceType = query.Type,
                TimeLimit = (float)query.TimeLimit,
                StepLimit = query.StepLimit,
                StartPage = query.StartPage,
                EndPage = query.EndPage
            };
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
        

        public async Task<List<Race>> GetRacesByTitle(string title)
        {
            List<Race> races = new List<Race>();
            var query = await _context.Races.Where(race => race.Title.Contains(title)).ToListAsync();
            foreach(var race in query)
            {
                races.Add(new Race
                {
                    Id = race.Id,
                    RaceTitle = race.Title,
                    RaceType = race.Type,
                    TimeLimit = (float)race.TimeLimit,
                    StepLimit = race.StepLimit,
                    StartPage = race.StartPage,
                    EndPage = race.EndPage,
                    AuthorId = race.AuthorId
                });
            }
            return races;
        }

        public Task UpdateRace(Race race)
        {
            throw new NotImplementedException();
        }
    }
}
