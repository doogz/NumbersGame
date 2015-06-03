using NUnit.Framework;

namespace ScottLogic.NumbersGame.ReferenceAlgorithms.Tests
{
    [TestFixture]
    public class ProgressiveRecursiveSolverTestFixture
    {

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void SimpleAddition()
        {
            var input = new [] {1, 2};
            var target = 3; 
            ISolution solution;
            var solver = new ProgressiveRecursiveSolver();
            bool solved = solver.GetSolution(input, target, out solution);
            Assert.AreEqual(true, solved);
            Assert.AreEqual(1, solution.NumberOfOperations);

        }

        [Test]
        public void MultiplicationAndAddition()
        {
            var input = new [] {10, 7, 2};
            int target=24;
            ISolution solution;
            var solver = new ProgressiveRecursiveSolver();
            bool solved = solver.GetSolution(input, target, out solution);
            Assert.AreEqual(true, solved);
            Assert.AreEqual(2, solution.NumberOfOperations);

        }

        [Test]
        public void DivisionAndSubtraction()
        {
            var input = new[] {10, 50, 1};
            int target= 4;
            ISolution solution;
            var solver = new ProgressiveRecursiveSolver();
            bool solved = solver.GetSolution(input, target, out solution);
            Assert.AreEqual(true, solved);
            Assert.AreEqual(2, solution.NumberOfOperations);

        }

        [Test]
        public void NotSolvableFor2()
        {
            var input = new[] {10, 5};
            int target = 3;
            ISolution solution;
            var solver = new ProgressiveRecursiveSolver();
            bool solved = solver.GetSolution(input, target, out solution);
            Assert.AreEqual(false, solved);
        }
        [Test]
        public void NotSolvableFor3()
        {
            var input = new[] { 10, 5, 1 };
            int target = 65;
            ISolution solution;
            var solver = new ProgressiveRecursiveSolver();
            bool solved = solver.GetSolution(input, target, out solution);
            Assert.AreEqual(false, solved);
        }

    }
}




