using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmWebApiClient.ViewModels;
using NUnit.Framework;
using ScottLogic.NumbersGame.Game;

namespace MvvmWebApiClient.Tests
{
    [TestFixture]
    public class NumbersGameViewModelTextFixture
    {
        private NumbersGameViewModel model;
        [SetUp]
        public void Setup()
        {
            model = new NumbersGameViewModel();
            
        }

        [TearDown]
        public void Teardown()
        {
            
        }
        [Test]
        public void CheckDefaultGame()
        {

        }

        [Test]
        public void Addition()
        {

        }
        [Test]
        public void SubtractionPermitted()
        {

        }

        [Test]
        public void SubtractionNotPermitted()
        {

        }

        [Test]
        public void NSquared()
        {
            // Test added because Multiplication does not work when Op1==Op2
            model.CurrentGame = new NumbersGame(new[] { 100, 5, 1, 5 });
            int expectedLength = 4;
            Assert.AreEqual(expectedLength, model.CurrentGame.NumberCount);
            model.SelectedNumbers = new[] {5, 5};
            Assert.AreEqual(true, model.OperationPossible);
            model.AdditionCommand.Execute(null);
            expectedLength--;
            Assert.AreEqual(expectedLength, model.CurrentGame.NumberCount);
        }



    }

}
