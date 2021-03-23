using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Model
{
    public class PathStep
    {
        private string _currentPage;

        private float _timeSpent;

        private int _stepNumber;
        public string CurrentPage
        {
            get { return _currentPage; }
            set
            {
                Regex pattern = new Regex(@"^\/wiki\/.+");
                if (pattern.IsMatch(value))
                {
                    _currentPage = value;
                }
                else
                {
                    throw new ArgumentException("Invalid url for wikirace page");
                }
            }
        }
        public float TimeSpent
        {
            get { return _timeSpent; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Time spent cannot be negative");
                }
                _timeSpent = value;
            }
        }
        public int StepNumber
        {
            get { return _stepNumber; }
            set
            {
                if(value < 1)
                {
                    throw new ArgumentException("Step number cannot be less than 1");
                }
                _stepNumber = value;
            }
        }

        public PathStep()
        {

        }

        public PathStep(string currentPage, float timeSpent, int stepNumber)
        {
            CurrentPage = currentPage;
            TimeSpent = timeSpent;
            StepNumber = stepNumber;
        }
    }
}
