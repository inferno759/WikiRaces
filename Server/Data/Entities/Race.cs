using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Entities
{
    public partial class Race
    {
        public Race()
        {
            LeaderboardLines = new HashSet<LeaderboardLine>();
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double TimeLimit { get; set; }
        public int StepLimit { get; set; }
        public string StartPage { get; set; }
        public string EndPage { get; set; }

        public virtual User Author { get; set; }
        public virtual ICollection<LeaderboardLine> LeaderboardLines { get; set; }
    }
}
