using System.Collections.Generic;
using ScottLogic.NumbersGame;

namespace NumbersGameWebAPI
{
    public class PuzzleRepository
    {
        private readonly IList<IPuzzle> _repo; 
        
        public PuzzleRepository()
        {
             _repo = new List<IPuzzle>();
            GenerateSomeGames();
        }

        public IPuzzle GetPuzzle(int id)
        {
            int idx = id%25;
            return _repo[id];
        }

        public IEnumerable<IPuzzle> GetAllPuzzles()
        {
            return _repo;
        }

        private void GenerateSomeGames()
        {
            int gameId = 0;
            for (int n = 0; n < 5; n++)
            {
                for (int big = 0; big <= 4; big++)
                {
                    int[] values;
                    int target;
                    if (GameGenerator.GenerateCountdownGame(big, out values, out target))
                    {
                        gameId++;
                        _repo.Add(new Puzzle(values, target));
                    }
                }
            }
        }
    }
}