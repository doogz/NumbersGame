using System;
using System.Collections.Generic;
using System.Linq;
using ScottLogic.NumbersGame.Game;

namespace ScottLogic.NumbersGame.ReferenceAlgorithms
{
    /// <summary>
    /// Implements a game solver (ISolutionProvider) based on a progressively deeper "brute force" approach.
    /// Every valid operation between every pair of numbers is tried in turn, and the process is applied recursively.
    /// From the initial starting point, a set of possible descendent games is generated; if any of these are solved, we are done.
    /// Games that aren't solved generate new descendent games, and these are added to a queue.
    /// The queue ensures that descendent games having greater numbers of operations are not processed until all those games with fewer operations have been.
    /// This algorithm naturally provides solutions according to acceptance criteria i.e. no unnecessary operations.
    /// 
    /// This solution is exclusively single-threaded, leaving room for improvement on multi-core machines.
    /// </summary>
    public class ProgressiveRecursiveSolver : ISolutionProvider
    {
        private readonly List<INumbersGame> _wip = new List<INumbersGame>(60); // work in progress

        public bool GetSolution(int[] inputNumbers, int target, out ISolution solution)
        {
            var initialNumbers = new Game.NumbersGame(inputNumbers) {Target = target};
            return GetSolution(initialNumbers, out solution);
        }

        private bool GetSolution(Game.NumbersGame initialGame, out ISolution solution)
        {
            var t0 = DateTime.Now;

            _wip.Add(initialGame);
            
            while (_wip.Any())
            {
                Console.WriteLine("PRSolver, number of games to look at : {0}", _wip.Count);

                // Process exactly the lists we had from the last iteration first
                // That begins at 1, for the single initial game
                int lists = _wip.Count;
                for (int idx = 0; idx < lists; ++idx)
                {
                    Console.WriteLine("PRSolver, Looking at game: {0}", idx);
                    INumbersGame game = _wip[idx];
                    if (game.IsSolved)
                    {
                        solution = new Solution(game.History);
                        return true;
                    }

                    if (!game.IsExhausted)
                    {
                        IList<INumbersGame> nextGames = game.CreateAllDescendents();
                        Console.WriteLine("Generates {0} descendent games", nextGames.Count);
                        _wip.AddRange(nextGames);
                    }
                }
                // We have dealt with (0,lists] now. RemoveRange does exactly what we need.
                _wip.RemoveRange(0, lists );
            }
            // There aint one
            solution = null;
            var t1 = System.DateTime.Now;
            var dt = t1 - t0;
            Console.WriteLine("Exhausting the possibilities took {0} s {1} ms", dt.Seconds, dt.Milliseconds);
            return false;
    
        }


        public bool GetShortestSolution(int[] inputNumbers, int target, out ISolution solution)
        {
            throw new NotImplementedException();
        }

    }
}

