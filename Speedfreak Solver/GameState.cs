using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottLogic.NumbersGame;

namespace SpeedFreak.NumberCrunch
{
    public interface IGameState
    {
        /// <summary>
        /// Values property is a simple array; no particular order is implied, and duplicates may be present.
        /// </summary>
        int[] Values { get; }
        int ValueCount { get; }

        int Apply(IOperation operation);
        void Undo(IOperation operation);
    }

    public class GameState : IGameState
    {
        private List<int> _values = new List<int>();


        public GameState(IEnumerable<int> initialValues)
        {
            _values.AddRange(initialValues);

        }
        public GameState(IGameState gameState)
        {
            _values.AddRange(gameState.Values);

        }


        public GameState(IEnumerable<int> initialValues, IEnumerable<IOperation> operations)
            :this(initialValues)
        {
            foreach(var op in operations)
                Apply(op);
        }

        public int Apply(IOperation op)
        {
            //TODO: If we can use our own Operation, we can support an extended interface e.g. IIndexedOperation
            //TODO: This would allow us to do the minimal amount of work here (No looking up indexes from values)
            _values.RemoveAt(_values.IndexOf(op.Lhs));
            _values.RemoveAt(_values.IndexOf(op.Rhs));
            _values.Add(op.Result);
            return op.Result;
        }

        public int Apply(IEnumerable<IOperation> ops)
        {
            int result = 0;
            foreach (var op in ops)
                result = Apply(op);
            return result;
        }


        public void Undo(IOperation op)
        {
            _values.RemoveAt(_values.IndexOf(op.Result));
            _values.Add(op.Lhs);
            _values.Add(op.Rhs);

        }

        public int[] Values
        {
            get { return _values.ToArray(); }
        }

        public int ValueCount
        {
            get { return _values.Count; }
        }
    }
}
