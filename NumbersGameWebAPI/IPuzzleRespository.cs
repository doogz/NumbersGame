using System.Collections.Generic;
using ScottLogic.NumbersGame;

namespace NumbersGameWebAPI
{
    public interface IPuzzleRepository
    {
        Puzzle GetPuzzle(int id);

        IEnumerable<Puzzle> GetAllPuzzles();

    }
}
