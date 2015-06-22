using System;
using System.Collections.Generic;
using System.Linq;
using ScottLogic.NumbersGame;

namespace SpeedFreak.NumberCrunch
{
    public class Solver : ISolutionProvider
    {
        public bool GetSolution(int[] inputNumbers, int target, out ISolution solution)
        {
            if (inputNumbers.Contains(target))
            {
                solution = new Solution(); // No operations required
                return true;
            }

            var game = new GameState(inputNumbers);
            var tree = new OperationsTree(game);
            if (tree.GenerateInitialOperations(target, out solution))
            {
                return true;
            }
            while (tree.HasPossibilities)
            {
                if (tree.GenerateNextOperations(target, out solution))
                {
                    return true;
                }
            }
            return false;
        }


        public bool GetShortestSolution(int[] inputNumbers, int target, out ISolution solution)
        {
            throw new NotImplementedException();
        }

        public bool GetAllSolutions(int[] inputNumbers, int target, out ISolution[] solutions)
        {
            throw new NotImplementedException();
        }
    }
}
