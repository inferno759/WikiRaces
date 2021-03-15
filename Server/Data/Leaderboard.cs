using System;
using System.Collections.Generic;

#nullable disable

namespace Dal
{
    public partial class Leaderboard
    {
        public Leaderboard()
        {
            PathSteps = new HashSet<PathStep>();
        }

        public int Id { get; set; }
        public int? RaceId { get; set; }
        public int? UserId { get; set; }
        public int? Score { get; set; }
        public double? TimeElapsed { get; set; }
        public int? StepsTaken { get; set; }
        public DateTime? CompletionDate { get; set; }

        public virtual Race Race { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PathStep> PathSteps { get; set; }
    }
}
