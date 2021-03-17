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
        public int Id { get; set; }

        // race ID foreign key done at Repo add

        // user ID foreign key done at Repo add

        public int Score
        {
            get { return _score; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Score shouldn't be negative or 0");
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




    }
}
