using System.Collections.Generic;
using ScottLogic.NumbersGame;

namespace SpeedFreak.NumberCrunch
{
    public interface TreeVisitor
    {
        void Visit(OperationsTree t);
    }

    public class OperationsTree
    {
        //private ConcurrentQueue<> 
        private IGameState _state;
        private List<LinkedOperation> _operations = new List<LinkedOperation>();

        public OperationsTree(IGameState state)//, IEnumerable<IOperation> initialOps)
        {
            _state = state;
            //_operations.AddRange(initialOps);
        }

        /// <summary>
        /// Accept method
        /// Implements the visited-class side of the visitor pattern
        /// </summary>

        public void Accept(object visitor)
        {
            TreeVisitor treeVisitor = visitor as TreeVisitor;
            foreach (var op in _operations)
            {
                
                if ( treeVisitor != null)
                    treeVisitor.Visit(this);

            }
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
