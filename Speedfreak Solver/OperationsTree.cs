using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using ScottLogic.NumbersGame;

namespace SpeedFreak.NumberCrunch
{
    

    public class OperationsTree
    {
        private static readonly Operator[] ReflexiveOperators = new[] { Operator.Addition, Operator.Multiplication, Operator.Division };

        private readonly IGameState _state;
        private int _turns;

        /// <summary>
        /// _operations holds the leaf-node operations that are possible after a number of moves.
        /// </summary>
        private List<IOperation> _operations = new List<IOperation>();

        public OperationsTree(IGameState state)
        {
            _state = state;
            _turns = _state.ValueCount - 1;

        }

        public bool HasPossibilities
        {
            get { return _turns > 1; }
        }

        public bool GenerateInitialOperations(int target, out ISolution solution)
        {
            if (Explore(null, _state, target, _operations))
            {
                solution = MakeSolution(_operations.ElementAt(_operations.Count - 1));
                return true;
            }
            solution = null;
            return false;
        }

        public ISolution MakeSolution(IOperation op)
        {
            ILinkedOperation opLinked = op as ILinkedOperation;
            if (opLinked != null)
            {
                IList<IOperation> ops = opLinked.GetSequence();
                return new Solution(ops);
            }
            return null;
         }

        public IGameState GetState(IOperation op)
        {
            var g = new GameState(_state);
            var operation = op as ILinkedOperation;
            if ( operation != null)
            {
                g.Apply(operation.GetSequence());
                return g;

            }
            return null;

        }

        public bool GenerateNextOperations(int target, out ISolution solution)
        {
            List<IOperation> nextOperations = new List<IOperation>();
            foreach (var op in _operations)
            {
                IGameState state = GetState(op);
                //state.Apply(op); // We don't care about the op's Result - we would have reacted during the previous Explore

                if (Explore(op, state, target, nextOperations))
                {
                    // One of our possibilities just hit our target, so we're done.
                    // We're guaranteed that it's the last one generated. Return a solution on the fly.
                    solution = MakeSolution(nextOperations.ElementAt(nextOperations.Count - 1));
                    return true;
                }
                    
                //state.Undo(op);

            }
            _operations = nextOperations;
            solution = null;
            --_turns;
            return false;

        }

        public void DumpArray(int[] array)
        {
            System.Console.Write("[");
            int len = array.Length;
            for (int n=0; n<len-1; ++n)
                System.Console.Write("{0}, ",array[n]);
            System.Console.WriteLine("{0}]", array[len-1]);
        }

        public bool Explore(IOperation parent, IGameState currentState, int target, IList<IOperation> operations)
        {
            // Get sorted list of values; we use the fact it's sorted to skip duplicates on the fly
            int[] values = currentState.Values;
            Array.Sort(values);


            // Generate our combinations
            int i1 = 0;
            while (i1 < values.Length - 1)
            {
                int n1 = values[i1];
                // For n2, start looking from the next index up. 
                int i2 = i1 + 1;
                // Check for repeated values.
                // Regardless of how many instances of a value we have, we can combine a value with itself in the same three ways,
                // n+n, n/n and n*n (but not n-n, as that yields an illegal zero)
                if (values[i2] == n1)
                {
                    foreach (var refOp in ReflexiveOperators)
                    {
                        var operation = new LinkedOperation(parent, n1, refOp, n1);
                        operations.Add(operation);
                        if (operation.Result == target) return true;
                    }
                    i2++;
                    // Keep scanning until we have a new value, or run out of columns
                    while (i2 < values.Length && values[i2] == n1)
                        i2++;
                }
                // If we did have a repeated value, we've scanned i2 past it now
                while (i2 < values.Length)
                {
                    int n2 = values[i2];
                    foreach (var op in (Operator[]) Enum.GetValues(typeof (Operator)))
                    {
                        if (Operation.IsValid(n1, n2, op))
                        {
                            var operation = new LinkedOperation(parent, n2, op, n1); // n2 >= n1 after Sort()
                            operations.Add(operation);
                            if (operation.Result == target)
                            {
                                return true;
                            }
                        }
                    }
                    ++i2;
                    // Move i2 onto next distinct value
                    while (i2 < values.Length && values[i2] == n2)
                        ++i2;
                }

                ++i1;
                while (i1 < values.Length - 1 && values[i1] == n1)
                    ++i1;
            }

            return false;
        }





        /// <param name="target"></param>
        /// <param name="solution"></param>
        /// <returns></returns>

        public bool FindSolution(int target, out ISolution solution)
        {
            foreach (var op in _operations)
            {
                if (_state.Apply(op) == target)
                {
                    var ops = new List<IOperation>();//GetSequence(LinkedOperation);

                    solution = new Solution(ops);
                    return true;
                }
                
                _state.Undo(op);

            }
            solution = null;
            return false;
        }
    }
}
