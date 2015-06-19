
using System.Linq;
using NUnit.Framework;
using ScottLogic.NumbersGame;

namespace ScottLogic.NumbersGameTests
{
    [TestFixture] 
    public class NumbersGameTestFixture
    {
        [Test]
        public void TwoOfTheSame()
        {
            var ng = new NumbersGame.Game.NumbersGamePlayer(new[] {2, 2, 10, 5, 75});
            var op = new Operation(2, 2, Operator.Multiplication);
            ng.DoOperation(op);
            Assert.Contains(4, ng.CurrentNumbers);
            // Repeat using different indices for good measure
            ng = new NumbersGame.Game.NumbersGamePlayer(new[] { 10, 2, 5, 2, 75 });
            ng.DoOperation(op);
            Assert.Contains(4, ng.CurrentNumbers);

        }
        [Test]
        public void Undo()
        {
            int[] initVars = {1,2,3,4,5};
            var ng = new NumbersGame.Game.NumbersGamePlayer(initVars);
            Assert.AreEqual(ng.NumberCount,5);

            var op = new Operation(4, 2, Operator.Subtraction);
            ng.DoOperation(op);
            Assert.AreEqual(1, ng.History.Count());
            int[] newVals = ng.CurrentNumbers;
            Assert.AreEqual(4, newVals.Length);
            Assert.AreEqual(new []{1,3,2,5}, ng.CurrentNumbers);
            Assert.True(ng.History.Count() == 1);
            ng.UndoOperation();
            int[] curVals = ng.CurrentNumbers;
            Assert.AreEqual(initVars, curVals);
            Assert.AreEqual(0, ng.History.Count());

        }
        
        [Test]
        public void AlreadySolved()
        {
            int[] initVars = {1};
            var game = new NumbersGame.Game.NumbersGamePlayer(initVars,1);
            Assert.AreEqual(true, game.IsSolved);
        }

        [Test]
        public void OneMoveAway()
        {
            int[] initVars = {1, 2};
            var game = new NumbersGame.Game.NumbersGamePlayer(initVars, 3);
            Assert.AreEqual(false, game.IsSolved);

            var op = new Operation(1, 2, Operator.Addition);
            game.DoOperation(op);
            Assert.AreEqual(true, game.IsSolved);
            Assert.AreEqual(true, game.IsExhausted);
        }


    }
}
