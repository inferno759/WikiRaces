using System;
using System.Collections.Generic;

#nullable disable

namespace Dal
{
    public partial class PathStep
    {
        public int Id { get; set; }
        public int? LeaderboardId { get; set; }
        public string CurrentPage { get; set; }
        public int? StepNumber { get; set; }
        public double? TimeSpent { get; set; }

        public virtual Leaderboard Leaderboard { get; set; }
    }
}
