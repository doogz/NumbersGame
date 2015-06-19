using System.Collections.Generic;
using System.Runtime.Serialization;
using ScottLogic.NumbersGame;

namespace ScottLogic.NumbersGame
{
    [DataContract]
    public class Puzzle : IPuzzle
    {
        private readonly List<int> _values = new List<int>();
        private readonly int _target;

        public Puzzle()
        {
            _target = 555;
        }
        public Puzzle(IEnumerable<int> startingValues, int target)
        {
            _values.Clear();
            _values.AddRange(startingValues);
            _target = target;
        }

        [DataMemberAttribute]
        public IEnumerable<int> StartingValues 
        {
            get { return _values; }
        }


        [DataMemberAttribute]
        public int TargetValue
        {
            get { return _target; }
        }
    }
}
