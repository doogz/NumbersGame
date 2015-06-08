using System;
using System.Collections.Generic;
using System.Linq;
using ScottLogic.NumbersGame;

namespace SpeedFreak.NumberCrunch
{
    /*
 
    public static class PossibilityExplorer
    {

        private static readonly Operator[] ReflexiveOperators = new[] { Operator.Addition, Operator.Multiplication, Operator.Division };

        static public bool Explore(IGameState currentState, int target, IList<IOperation> operations)
        {
            // Get sorted list of values; we use the fact it's sorted to skip duplicates on the fly, as follows.
            //possibleOperations = new List<IOperation>();
            int[] values = currentState.Values;
            Array.Sort(values);

            // Generate our combinations
            int i1 = 0;
            while (i1<values.Length-1)
            {
                int n1 = values[i1];
                // For n2, start looking from the next index up. 
                int i2 = i1 + 1;
                if ( values[i2] == n1) // It is a repeat, and i2 < values.Length because i1 < values.Length-1
                {
                    // We have multiple instances of value 'n1'.
                    // Regardless of how many we have, we can combine with ourselves to produce 2*n, n*n and 1
                    foreach (var refOp in ReflexiveOperators)
                    {
                        var operation = new LinkedOperation(n1, refOp, n1);
                        operations.Add(operation);
                        if (operation.Result == target)
                        {
                            return true;
                        }
                    }

                    i1 = i2+1;
                    // Look ahead for more repetitions
                    while (i1 < values.Length - 1 && values[i1] == n1)
                        ++i1;
                }
                else
                {
                    while (i2<values.Length)
                    {
                        int n2 = values[i2];
                        // Skip any repeated N2s
                        foreach (var op in (Operator[]) Enum.GetValues(typeof (Operator)))
                            if (Operation.IsValid(n1, n2, op))
                            {
                                var operation = new LinkedOperation(n2, op, n1); // n2 >= n1 after Sort()
                                operations.Add(operation);
                                if (operation.Result == target)
                                {
                                    return true;
                                }
                            }
                        ++i2;
                        while (i2 < values.Length && values[i2] == n2)
                            ++i2;
                    }
                    ++i1;
                }

            }
            return false;
        }
    }
     * */
}
