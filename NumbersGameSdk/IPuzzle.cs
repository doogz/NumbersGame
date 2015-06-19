using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottLogic.NumbersGame
{
    /// <summary>
    /// Describes the puzzle posed as the starting point of a numbers game.
    /// This is the puzzle at its most basic; there is no metadata in this interface e.g. how hard the puzzle is known to be, which ruleset applies...
    /// </summary>
    public interface IPuzzle
    {
        IEnumerable<int> StartingValues { get; }
        int TargetValue { get; }
    }
}
