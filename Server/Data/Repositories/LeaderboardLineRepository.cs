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
    public class LeaderboardLineRepository : ILeaderBoardLineRepository
    {
        private readonly Entities.Project2Context _context;

        public LeaderboardLineRepository(Entities.Project2Context context)
        {
            _context = context;
        }

        public async Task AddLeaderboardLine(LeaderboardLine leaderboardLine)
        {
            Entities.LeaderboardLine newLine = new Entities.LeaderboardLine
            {
                RaceId = leaderboardLine.RaceId,
                UserId = leaderboardLine.UserId,
                Score = leaderboardLine.Score,
                TimeElapsed = leaderboardLine.TimeElapsed,
                StepsTaken = leaderboardLine.StepsTaken,
                CompletionDate = leaderboardLine.LeaderboardDateTime,
                PathSteps = leaderboardLine.Path.Select(ps => new Entities.PathStep
                {
                    CurrentPage = ps.CurrentPage,
                    StepNumber = ps.StepNumber,
                    TimeSpent = ps.TimeSpent
                }).ToList()
            };
            await _context.AddAsync(newLine);
            await _context.SaveChangesAsync();
        }

        public Task DeleteLeaderBoardLine(LeaderboardLine leaderboardLine)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaderboardLine> GetLeaderboardLineByID(int id)
        {
            Entities.LeaderboardLine query;
            try
            {
                query = await _context.LeaderboardLines
                    .Include(l => l.PathSteps)
                    .Include(u => u.User)
                    .FirstAsync(x => x.Id == id);
            }
            catch
            {
                throw new ArgumentException("Could not find leaderboard line with that ID");
            }
            LeaderboardLine leaderboardLine = new LeaderboardLine
            {
                Id = query.Id,
                RaceId = query.RaceId,
                UserId = query.UserId,
                Score = query.Score,
                TimeElapsed = (float)query.TimeElapsed,
                StepsTaken = query.StepsTaken,
                LeaderboardDateTime = query.CompletionDate,
                Path = query.PathSteps.Select(ps => new PathStep
                {
                    CurrentPage = ps.CurrentPage,
                    TimeSpent = (float)ps.TimeSpent,
                    StepNumber = ps.StepNumber
                }).ToList(),
                User = new User
                {
                    Id = query.User.Id,
                    Username = query.User.Username,
                    Password = query.User.Password,
                }
            };
            return leaderboardLine;
        }

        public async Task<List<LeaderboardLine>> GetLeaderboardLines()
        {
            List<LeaderboardLine> leaderboardLines = new List<LeaderboardLine>();
            var query = await _context.LeaderboardLines
                .Include(l => l.PathSteps)
                .Include(u => u.User)
                .ToListAsync();
            foreach (var leaderboardLine in query)
            {
                leaderboardLines.Add(new LeaderboardLine
                {
                    Id = leaderboardLine.Id,
                    RaceId = leaderboardLine.RaceId,
                    UserId = leaderboardLine.UserId,
                    Score = leaderboardLine.Score,
                    TimeElapsed = (float)leaderboardLine.TimeElapsed,
                    StepsTaken = leaderboardLine.StepsTaken,
                    LeaderboardDateTime = leaderboardLine.CompletionDate,
                    Path = leaderboardLine.PathSteps.Select(ps => new PathStep
                    {
                        CurrentPage = ps.CurrentPage,
                        StepNumber = ps.StepNumber,
                        TimeSpent = (float)ps.TimeSpent
                    }).ToList(),
                    User = new User
                    {
                        Id = leaderboardLine.User.Id,
                        Username = leaderboardLine.User.Username,
                        Password = leaderboardLine.User.Password,
                    }
                });
            }
            return leaderboardLines;
        }

        public async Task<List<LeaderboardLine>> GetLeaderboardLinesByRace(int raceId)
        {
            List<LeaderboardLine> leaderboardLines = new List<LeaderboardLine>();
            var query = await _context.LeaderboardLines
                .Include(l => l.PathSteps)
                .Include(u => u.User)
                .Where(x => x.RaceId == raceId)
                .ToListAsync();
            foreach (var leaderboardLine in query)
            {
                leaderboardLines.Add(new LeaderboardLine
                {
                    Id = leaderboardLine.Id,
                    RaceId = leaderboardLine.RaceId,
                    UserId = leaderboardLine.UserId,
                    Score = leaderboardLine.Score,
                    TimeElapsed = (float)leaderboardLine.TimeElapsed,
                    StepsTaken = leaderboardLine.StepsTaken,
                    LeaderboardDateTime = leaderboardLine.CompletionDate,
                    Path = leaderboardLine.PathSteps.Select(ps => new PathStep
                    {
                        CurrentPage = ps.CurrentPage,
                        StepNumber = ps.StepNumber,
                        TimeSpent = (float)ps.TimeSpent
                    }).ToList(),
                    User = new User
                    {
                        Id = leaderboardLine.User.Id,
                        Username = leaderboardLine.User.Username,
                        Password = leaderboardLine.User.Password,
                    }
                });
            }
            return leaderboardLines;
        }

        public async Task<List<LeaderboardLine>> GetLeaderboardLinesByUser(int userId)
        {
            List<LeaderboardLine> leaderboardLines = new List<LeaderboardLine>();
            var query = await _context.LeaderboardLines
                .Include(l => l.PathSteps)
                .Include(u => u.User)
                .Where(x => x.UserId == userId)
                .ToListAsync();
            foreach (var leaderboardLine in query)
            {
                leaderboardLines.Add(new LeaderboardLine
                {
                    Id = leaderboardLine.Id,
                    RaceId = leaderboardLine.RaceId,
                    UserId = leaderboardLine.UserId,
                    Score = leaderboardLine.Score,
                    TimeElapsed = (float)leaderboardLine.TimeElapsed,
                    StepsTaken = leaderboardLine.StepsTaken,
                    LeaderboardDateTime = leaderboardLine.CompletionDate,
                    Path = leaderboardLine.PathSteps.Select(ps => new PathStep
                    {
                        CurrentPage = ps.CurrentPage,
                        StepNumber = ps.StepNumber,
                        TimeSpent = (float)ps.TimeSpent
                    }).ToList(),
                    User = new User
                    {
                        Id = leaderboardLine.User.Id,
                        Username = leaderboardLine.User.Username,
                        Password = leaderboardLine.User.Password,
                    }
                });
            }
            return leaderboardLines;
        }

        public Task UpdateLeaderBoardLine(LeaderboardLine leaderboardLine)
        {
            throw new NotImplementedException();
        }
    }
}
