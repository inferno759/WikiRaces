using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Race
    {

        private string _raceTitle;
        private string _raceType;
        private float _timeLimit;
        private int _stepLimit;
        private string _startPage;
        private string _endPage;

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
                if (value.Any(char.IsSymbol) || value.Any(char.IsPunctuation))
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
        public int StepLimit 
        { 
            get{ return _stepLimit; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Step limit cannot be less than 1");
                }
                _stepLimit = value;
            }
        }

        public string StartPage
        {
            get { return _startPage; }
            set
            {
                Regex pattern = new Regex(@"^\/wiki\/.+");
                if (pattern.IsMatch(value))
                {
                    _startPage = value;
                }
                else
                {
                    throw new ArgumentException("Invalid url for wikirace start page");
                }
            }
        }

        public string EndPage
        {
            get { return _endPage; }
            set
            {
                Regex pattern = new Regex(@"^\/wiki\/.+");
                if (pattern.IsMatch(value))
                {
                    _endPage = value;
                }
                else
                {
                    throw new ArgumentException("Invalid url for wikirace end page");
                }
            }
        }

        public Race()
        {

        }

        public Race(int id, int authorId, string title, string type, float timeLimit, int stepLimit, string start, string end)
        {
            Id = id;
            AuthorId = authorId;
            RaceTitle = title;
            RaceType = type;
            TimeLimit = timeLimit;
            StepLimit = stepLimit;
            StartPage = start;
            EndPage = end;
        }
    }
}