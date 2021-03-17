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
        Task<IEnumerable<LeaderboardLine>> GetLeaderboardLines();
        Task<IEnumerable<LeaderboardLine>> GetLeaderboardLinesByUser(User user);
        Task<IEnumerable<LeaderboardLine>> GetLeaderboardLinesByRace(Race race);
        Task UpdateLeaderBoardLine(LeaderboardLine leaderboardLine);
        Task DeleteLeaderBoardLine(LeaderboardLine leaderboardLine);
    }
}
