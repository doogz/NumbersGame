using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ScottLogic.NumbersGame
{
    /// <summary>
    /// Library implementation of ISolution based on an ordered, indexed list of operations.
    /// Algorithm (ISolutionProvider) implementors should use this class for returning their results.
    /// SDK clients, further down the chain and seeing only ISolution, don't get to modify properties, but do get read access via the interface.
    /// </summary>

    public class Solution : ISolution
    {
        /// <summary>
        /// Game solvers are expected to support three different requirements
        /// </summary>
        public enum Goal
        {
            [Description("First solution found")]
            FirstFound,
            [Description("Fewest number of operations")]
            FewestOperations,
            [Description("Using all numbers")]
            UseAllNumbers
        }

        private readonly List<IOperation> _operations = new List<IOperation>();

        public Solution(IEnumerable<IOperation> operations)
        {
            _operations.AddRange(operations);
        }
        /// <summary>
        /// Implements ISolution.GetMultilineDisplayString
        /// Note: This method returns a platform-specific multi-line string.
        /// That's fine for display on the same machine, but not necessarily over the wire.
        /// </summary>
        public string GetMultilineDisplayString()
        {
            // There are only a few steps (five or less in the official game with 6 numbers), 
            // so this multiple concatenation isn't too bad in itself, especially with a string builder.
            // But, IOperation.DisplayString (which it calls) is already a property that does a bit of work (string concatenation).
            // This being the case, this is defined as a Method rather than a Property.
            var sb=new StringBuilder();
            foreach (var op in _operations)
                sb.AppendLine(op.DisplayString);

            return sb.ToString();
        }
        /// <summary>
        /// Public utility method for individually adding operations. 
        /// Intended for solutions with a custom data structure (not necessarily an enumerable list of operations)
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public void AddOperation(IOperation operation)
        {
            _operations.Add(operation); // 
        }
        /// <summary>
        /// Implements ISolution.NumberOfOperations
        /// </summary>
        public int NumberOfOperations
        {
            get { return _operations.Count; }
        }

        /// <summary>
        /// Public indexer for the operations leading to the solution.
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public IOperation this[int idx]
        {
            get { return _operations[idx]; }
            set { _operations[idx] = value; }
        }

    }
}
