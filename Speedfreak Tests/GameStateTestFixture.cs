using System;
using NUnit.Framework;
using ScottLogic.NumbersGame;
using SpeedFreak.NumberCrunch;

namespace Speedfreak_Tests
{
    [TestFixture]
    public class GameStateTestFixture
    {
        [Test]
        public void SimpleConstructor()
        {
            var game = new GameState(new[] {1, 2, 3});
            Assert.AreEqual(3, game.ValueCount);
        }

        [Test]
        public void SimpleAddition()
        {
            var game = new GameState(new[] { 1, 2, 3 });
            var op = new Operation(2, 3, Operator.Addition);
            Assert.AreEqual(5, op.Result);
            game.Apply(op);
            Assert.AreEqual(2, game.ValueCount);

            game.Undo(op);
            Assert.AreEqual(3, game.ValueCount);
            var undone = game.Values;
            Array.Sort(undone);
            Assert.AreEqual(new []{1,2,3}, undone);


        }
    }
}
