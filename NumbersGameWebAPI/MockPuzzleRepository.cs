using System;
using System.Collections.Generic;
using ScottLogic.NumbersGame;

namespace NumbersGameWebAPI
{
    public class MockPuzzleRepository : IPuzzleRepository, IDisposable
    {
        private readonly List<Puzzle> _repo; 
        
        public MockPuzzleRepository()
        {
             _repo = new List<Puzzle>();
            GenerateSomeGames();
        }

        public Puzzle GetPuzzle(int id)
        {
            int idx = id%25;
            return _repo[id];
        }

        public IEnumerable<Puzzle> GetAllPuzzles()
        {
            return _repo;
        }

        private void GenerateSomeGames()
        {
            for (int n = 0; n < 5; n++)
                for (int big = 0; big <= 4; big++)
                {
                    int[] values;
                    int target;
                    if (GameGenerator.GenerateCountdownGame(big, out values, out target))
                        _repo.Add(new Puzzle(values, target));
                }
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                /*
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
                 */
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }
    }
}