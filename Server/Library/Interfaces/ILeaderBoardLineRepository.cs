using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Interfaces
{
    public interface ILeaderBoardLineRepository
    {
        Task AddLeaderboardLine(LeaderboardLine leaderboardLine);
        Task<LeaderboardLine> GetLeaderboardLineByID(int id);
        Task<List<LeaderboardLine>> GetLeaderboardLines();
        Task<List<LeaderboardLine>> GetLeaderboardLinesByUser(User user);
        Task<List<LeaderboardLine>> GetLeaderboardLinesByRace(Race race);
        Task UpdateLeaderBoardLine(LeaderboardLine leaderboardLine);
        Task DeleteLeaderBoardLine(LeaderboardLine leaderboardLine);
    }
}
