using System;
using System.Collections.Generic;
using System.Linq;
using ScottLogic.NumbersGame;

namespace SpeedFreak.NumberCrunch
{
    public static class PossibilityExplorer
    {
        static public IEnumerable<IOperation> Explore(IGameState currentState)
        {
            // Get sorted list of values; we use the fact it's sorted to skip duplicates on the fly, as follows.
            List<IOperation> ops = new List<IOperation>();
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
                    ops.Add(new LinkedOperation(n1, Operator.Addition, n1));
                    ops.Add(new LinkedOperation(n1, Operator.Multiplication, n1));
                    ops.Add(new LinkedOperation(n1, Operator.Division, n1));

                    i1 = i2+1;
                    // Look ahead for more repetitions
                    while (i1 < values.Length - 1 && values[i1] == n1)
                        ++i1;
                }
                else
                {
                    int n2 = values[i2];
                    while (i2<values.Length)
                    {
                        // Skip any repeated N2s
                        foreach (var op in (Operator[]) Enum.GetValues(typeof (Operator)))
                            if (Operation.IsValid(n1, n2, op))
                                ops.Add(new LinkedOperation(n1, op, n2));// n1 > n2
                        ++i2;
                        while (i2 < values.Length && values[i2] == n2)
                            ++i2;
                    }
                    ++i1;
                }

            }
            return ops;
        }
    }
}
