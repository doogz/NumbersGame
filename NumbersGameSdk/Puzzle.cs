using System.Collections.Generic;
using System.Runtime.Serialization;
using ScottLogic.NumbersGame;

namespace ScottLogic.NumbersGame
{
    // [DataContract]
    public class Puzzle : IPuzzle
    {
        private readonly List<int> _values = new List<int>();
        private int _target;
        private Puzzle()
        { }
        public Puzzle(IEnumerable<int> startingValues, int target)
        {
            _values.Clear();
            _values.AddRange(startingValues);
            _target = target;
        }

        // [DataMemberAttribute]
        public IEnumerable<int> StartingValues 
        {
            get { return _values; }
            set
            {
                _values.Clear();
                _values.AddRange(value);
            }
        }

        // #Discuss: These attributes were recommended, but this stuff is in the SDK, and those attributes are recommended for the
        // client application that is using it. I've sullied the API? Derive from this class inside the client and add the attributes there, perhaps
        // the best way to deal with this properly - ?
        // [DataMemberAttribute]
        public int TargetValue
        {
            get { return _target; }
            set { _target = value; }
        }
    }
}
