using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace ScottLogic.NumbersGame.ReferenceAlgorithms
{
    /// <summary>
    /// In contrast to the progressive recursive solver, the deep recursive solver uses recursion exhaustively from the off.
    /// Whereas the former attempts to find solutions using 1 operation, 2 operations, 3 operations etc - progressively - this
    /// solver resurses to the lowest depths before bubbling back out (and in).
    /// Due to the unprogressive nature of the search, it's entirely possible that we come up with a "solution" that contains
    /// unnecessary operations.
    /// </summary>
    [Description("Brute-force deep recursive undoing solver")]
    public class DeepRecursiveUndoingSolver : ISolutionProvider
    {
#if UsingUnityYet
        static DeepRecursiveUndoingSolver()
        {
            // Where to get our IoC container??
            
            var container = new UnityContainer();

            // Registering...
            container.RegisterType<ISolutionProvider, DeepRecursiveUndoingSolver>();

            // Resolving...
            var solution = container.Resolve<Solution>();
        }
#endif
        public bool GetSolution(int[] inputNumbers, int target, out ISolution solution)
        {
            var initialNumbers = new Game.NumbersGamePlayer(inputNumbers, target);
            return GetSolution(initialNumbers, out solution);
        }

        private bool GetSolution(Game.NumbersGamePlayer gamePlayer, out ISolution solution)
        {
            var timer = Stopwatch.StartNew();
            bool solved = Solve(gamePlayer);
            solution = new Solution(gamePlayer.History);
            return solved;
        }


        private bool Solve(Game.NumbersGamePlayer gamePlayer)
        {
            if (gamePlayer.IsSolved) return true;

            int numbers = gamePlayer.NumberCount;
            int maxIdx0 = numbers - 1;
            for (int idx0 = 0; idx0 < maxIdx0; ++idx0)
            {
                int n1 = gamePlayer.GetNumber(idx0);
                for (int idx1 = idx0 + 1; idx1 < numbers; ++idx1)
                {
                    int n2 = gamePlayer.GetNumber(idx1);
                    foreach (Operator op in Enum.GetValues(typeof (Operator)))
                    {
                        if (Operation.IsValid(n1, n2, op))
                        {
                            gamePlayer.DoOperation(new Operation(n1, n2, op));
                            if (gamePlayer.IsSolved) return true;
                            if (gamePlayer.NumberCount >= 2 && Solve(gamePlayer)) return true;
                            gamePlayer.UndoOperation();
                        }
                    }

                }
            }
            return false;
        }

        private List<ISolution> _solutions = new List<ISolution>();

        public bool GetAllSolutions(int[] inputNumbers, int target, out ISolution[] solutions)
        {
            _solutions.Clear();
            var gamePlayer = new Game.NumbersGamePlayer(inputNumbers, target);
            GetSolutions(gamePlayer, out solutions);
            return solutions.Any();
        }

        private void GetSolutions(Game.NumbersGamePlayer gamePlayer, out ISolution[] solutions)
        {
            int numbers = gamePlayer.NumberCount;
            int maxIdx0 = numbers - 1;
            for (int idx0 = 0; idx0 < maxIdx0; ++idx0)
            {
                int n1 = gamePlayer.GetNumber(idx0);
                for (int idx1 = idx0 + 1; idx1 < numbers; ++idx1)
                {
                    int n2 = gamePlayer.GetNumber(idx1);
                    foreach (Operator op in Enum.GetValues(typeof (Operator)))
                    {
                        if (Operation.IsValid(n1, n2, op) && !gamePlayer.IsSolved)
                        {
                            gamePlayer.DoOperation(new Operation(n1, n2, op));
                            // If this is the operation that solves our game, we want the solution
                            if (gamePlayer.IsSolved)
                            {
                                var sol = new Solution(gamePlayer.History);
                                _solutions.Add(sol);
                            }
                            // But it it didn't sove our game, we need to recurse
                            else if (gamePlayer.NumberCount >= 2)
                            {
                                GetSolutions(gamePlayer, out solutions);
                            }
                            // Either way, we always undo our operation before trying another (within a given call of this method)
                            gamePlayer.UndoOperation();
                        }
                    }

                }
            }
            solutions = _solutions.ToArray();
        }





        public bool GetShortestSolution(int[] inputNumbers, int target, out ISolution solution)
        {
            throw new NotImplementedException();
        }
        
    }
}
