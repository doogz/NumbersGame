using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ScottLogic.NumbersGame;
using SpeedFreak.NumberCrunch;

namespace Speedfreak_Tests
{
    [TestFixture]
    
    public class PossibilityExplorerTestFixture
    {
        [Test]
        void foo()
        {
            GameState game = new GameState(new[]{5,7});
            var ops = PossibilityExplorer.Explore(game);
            Assert.AreEqual(3, ops.Count());



        }
    }
}
