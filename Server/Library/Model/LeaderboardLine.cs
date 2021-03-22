using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class LeaderboardLine
    {

        private int _score;
        private float _timeElapsed;
        private int _stepsTaken;

        public LeaderboardLine()
        {

        }

        public LeaderboardLine(int id, int raceId, int userId, int score, float timeElapsed, int stepsTaken,
            DateTime leaderBoardDateTime, List<PathStep> paths, User user)
        {
            Id = id;
            RaceId = raceId;
            UserId = userId;
            Score = score;
            TimeElapsed = timeElapsed;
            StepsTaken = stepsTaken;
            LeaderboardDateTime = leaderBoardDateTime;
            Path = paths;
            User = user;
        }


        public int Id { get; set; }

        public int RaceId { get; set; }

        public int UserId { get; set; }

        public int Score
        {
            get { return _score; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score shouldn't be negative");
                }
                else
                {
                    _score = value;
                }
            }
        }
        public float TimeElapsed
        {
            get { return _timeElapsed; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("TimeElapsed should not be negative or 0");
                }
                else
                {
                    _timeElapsed = value;
                }
            }
        }
        public int StepsTaken
        {
            get { return _stepsTaken; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("StepsTaken should not be negative or 0");
                }
                else
                {
                    _stepsTaken = value;
                }
            }
        }
        public DateTime LeaderboardDateTime { get; set; }

        public List<PathStep> Path { get; set; }

        public User User { get; set; }


    }
}
