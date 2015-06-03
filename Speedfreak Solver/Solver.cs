using System;
using ScottLogic.NumbersGame;

namespace SpeedFreak.NumberCrunch
{
    public class Solver : ISolutionProvider
    {
        public bool GetSolution(int[] inputNumbers, int target, out ISolution solution)
        {
            var game = new GameState(inputNumbers);
            var ops = PossibilityExplorer.Explore(game);
            //var tree = new OperationsTree(game, ops);
            //return tree.FindSolution(target, out ISolution);
            throw new Exception("Eggs");
        }


        public bool GetShortestSolution(int[] inputNumbers, int target, out ISolution solution)
        {
            throw new System.NotImplementedException();
        }
    }
}
