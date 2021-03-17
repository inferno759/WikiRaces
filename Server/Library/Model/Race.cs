using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Race
    {

        private string _raceTitle;
        private string _raceType;
        private float _timeLimit;

        public int Id { get; set; }
        public int AuthorId { get; set; }

        public string RaceTitle 
        {
            get { return _raceTitle; }
            set
            {
                if(value.Length < 3)
                {
                    throw new ArgumentException("RaceTitle should be at least 3 characters long");
                }
                else if(value.Length > 80)
                {
                    throw new ArgumentException("RaceTitle shouldn't be longer than 80 characters");
                }
                if(value.Any(char.IsSymbol))
                {
                        throw new ArgumentException("RaceTitle should not have any symbols");
                }
                _raceTitle = value;
            }
        }
        public string RaceType
        {
            get { return _raceType; }
            set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("RaceType should be at least 3 characters long");
                }
                else if (value.Length > 40)
                {
                    throw new ArgumentException("RaceType shouldn't be longer than 40 characters");
                }
                else
                {
                    _raceType = value;
                }
            }
        }
        public float TimeLimit
        {
            get { return _timeLimit; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("TimeLimit cannot be negative or 0");
                }
                else
                {
                    _timeLimit = value;
                }
            }
        }
        public int StepLimit { get; set; }

        public string StartPage { get; set; }

        public string EndPage { get; set; }

    }
}