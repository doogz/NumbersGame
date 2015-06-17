using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            model.CurrentGame = new NumbersGame(new[] { 100, 25, 5, 7, 7, 5 });
        }

        [TearDown]
        public void Teardown()
        {
            model.CurrentGame = null;
            model = null;
        }
        [Test]
        public void CheckDefaultGameProperties()
        {
            // We should begin with 6 numbers, and in a state where operations are not possible, (nor the undoing thereof).
            Assert.AreEqual(6, model.CurrentGame.NumberCount);
            Assert.False(model.OperationPossible);
            Assert.False(model.UndoPossible);
            Assert.AreEqual(0, model.SelectedNumbers.Count);
        }

        [Test]
        public void Addition()
        {
            model.SelectedNumbers = new[] { 25, 7 };
            Assert.AreEqual(true, model.OperationPossible);
            model.AdditionCommand.Execute(null);
            Assert.AreEqual(5, model.CurrentGame.NumberCount);
            Assert.Contains(32, model.CurrentGame.CurrentNumbers);
        }
        [Test]
        public void Subtraction()
        {
            model.SelectedNumbers = new[] { 7, 25 };
            Assert.AreEqual(true, model.OperationPossible);
            model.SubtractionCommand.Execute(null);
            Assert.AreEqual(5, model.CurrentGame.NumberCount);
            Assert.Contains(18, model.CurrentGame.CurrentNumbers);
        }

        [Test]
        public void Multiplication()
        {
            model.SelectedNumbers = new[] { 5, 7 };
            Assert.AreEqual(true, model.OperationPossible);
            model.MultiplicationCommand.Execute(null);
            Assert.AreEqual(5, model.CurrentGame.NumberCount);
            Assert.AreEqual(1, model.CurrentGame.CurrentNumbers.Count((i) => i == 5)); // only 1x'5' left
            Assert.AreEqual(1, model.CurrentGame.CurrentNumbers.Count((i) => i == 7)); // only 1x'7' left
            Assert.Contains(35, model.CurrentGame.CurrentNumbers);
        }


        [Test]
        public void Squared()
        {
            // Test added because I noticed an issue when trying to multiply two numbers with the same value 
            model.SelectedNumbers = new[] { 7, 7 };
            Assert.AreEqual(true, model.OperationPossible);
            model.MultiplicationCommand.Execute(null);
            Assert.AreEqual(5, model.CurrentGame.NumberCount);
            Assert.AreEqual(0, model.CurrentGame.CurrentNumbers.Count((i) => i == 7)); // No 7s left
            Assert.Contains(49, model.CurrentGame.CurrentNumbers);
        }



        [Test]
        public void Division()
        {
            model.SelectedNumbers = new[] { 100, 25 };
            Assert.AreEqual(true, model.OperationPossible);
            model.DivisionCommand.Execute(null);
            Assert.AreEqual(5, model.CurrentGame.NumberCount);
            Assert.False(model.CurrentGame.CurrentNumbers.Contains(100));
            Assert.False(model.CurrentGame.CurrentNumbers.Contains(25));
            Assert.Contains(4, model.CurrentGame.CurrentNumbers);
        }

        [Test]
        public void DoesSelectionResetAfterOperation()
        {
            // Numbers at beginning
            model.SelectedNumbers = new[] {100, 25};
            model.AdditionCommand.Execute(null);
            Assert.AreEqual(0,model.SelectedNumbers.Count);

        }




    }

}
