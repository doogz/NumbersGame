using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame
{
    public class Puzzle : IPuzzle
    {
        private readonly List<int> _values = new List<int>();
        private readonly int _target;

        public Puzzle(IEnumerable<int> startingValues, int target)
        {
            _values.Clear();
            _values.AddRange(startingValues);
            _target = target;
        }

        public IEnumerable<int> StartingValues 
        {
            get { return _values; }
        }

        public int TargetValue
        {
            get { return _target; }
        }
    }
}
