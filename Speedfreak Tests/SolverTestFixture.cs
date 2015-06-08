using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScottLogic.NumbersGame;
using SpeedFreak.NumberCrunch;

namespace Speedfreak_Tests
{
    [TestFixture]
    public class SolverTestFixture
    {
        [Test]
        public void AlreadySolved()
        {
            int[] initialValues = new int[] {10,25,100,6,8,3};
            var solver = new Solver();
            ISolution solution;
            Assert.AreEqual(true, solver.GetSolution(initialValues, 100, out solution));
            Assert.AreEqual(0, solution.NumberOfOperations);
        }
        [Test]
        public void OneAdditionAway()
        {
            int[] initialValues = new int[] { 10, 25, 100, 6, 8, 3 };
            var solver = new Solver();
            ISolution solution;
            Assert.AreEqual(true, solver.GetSolution(initialValues, 106, out solution));
            Assert.AreEqual(1, solution.NumberOfOperations);
            IOperation op = solution[0];
            Assert.AreEqual(Operator.Addition, op.Operator);
            Assert.AreEqual(106, op.Result);
            Assert.AreEqual(true, op.Lhs == 100);
            Assert.AreEqual(true, op.Rhs == 6);

        }

        [Test]
        public void OneSubtractionAway()
        {
            int[] initialValues = new[] {10, 100, 7, 25};
            var solver = new Solver();
            ISolution solution;
            Assert.AreEqual(true, solver.GetSolution(initialValues, 93, out solution));
            Assert.AreEqual(1, solution.NumberOfOperations);
            IOperation op = solution[0];
            
            Assert.AreEqual(93, op.Result);
            Assert.AreEqual(Operator.Subtraction, op.Operator);
            Assert.AreEqual(true, op.Lhs == 100);
            Assert.AreEqual(true, op.Rhs == 7);
        }

        [Test]
        public void OneMultiplicationAway()
        {
            int[] initialValues = new[] { 3, 5, 7, 10, 25, 100};
            var solver = new Solver();
            ISolution solution;
            Assert.AreEqual(true, solver.GetSolution(initialValues, 700, out solution));
            Assert.AreEqual(1, solution.NumberOfOperations);
            IOperation op = solution[0];

            Assert.AreEqual(700, op.Result);
            Assert.AreEqual(Operator.Multiplication, op.Operator);
            Assert.AreEqual(true, op.Lhs == 100);
            Assert.AreEqual(true, op.Rhs == 7);
        }


        [Test]
        public void OneDivisionAway()
        {
            int[] initialValues = new[] { 75, 7, 25, 100 };
            var solver = new Solver();
            ISolution solution;
            Assert.AreEqual(true, solver.GetSolution(initialValues, 3, out solution));
            Assert.AreEqual(1, solution.NumberOfOperations);
            IOperation op = solution[0];

            Assert.AreEqual(3, op.Result);
            Assert.AreEqual(Operator.Division, op.Operator);
            Assert.AreEqual(true, op.Lhs == 75);
            Assert.AreEqual(true, op.Rhs == 25);
        }

        [Test]
        public void AdditionThenMultiplcation()
        {
            int[] initialValues = new[] { 75, 7, 25, 6, 1, 9 };
            var solver = new Solver();
            ISolution solution;
            Assert.AreEqual(true, solver.GetSolution(initialValues, 900, out solution));
            Console.WriteLine(solution.GetMultilineDisplayString());

            Assert.AreEqual(2, solution.NumberOfOperations);
            IOperation op = solution[0];

            Assert.AreEqual(100, op.Result);
            Assert.AreEqual(Operator.Addition, op.Operator);
            Assert.AreEqual(true, op.Lhs == 75);
            Assert.AreEqual(true, op.Rhs == 25);
            op = solution[1];
            Assert.AreEqual(900, op.Result);
            Assert.AreEqual(Operator.Multiplication, op.Operator);
            Assert.AreEqual(true, op.Lhs == 100);
            Assert.AreEqual(true, op.Rhs == 9);


        }
        [Test]
        public void SubtractionThenMultipilcationThenAddition()
        {
            int[] initialValues = new[] { 75, 3, 25, 7 };
            var solver = new Solver();
            ISolution solution;
            Assert.AreEqual(true, solver.GetSolution(initialValues, 353, out solution));
            Console.WriteLine(solution.GetMultilineDisplayString());

            Assert.AreEqual(3, solution.NumberOfOperations);
            IOperation op = solution[0];

            Assert.AreEqual(50, op.Result);
            Assert.AreEqual(Operator.Subtraction, op.Operator);
            Assert.AreEqual(true, op.Lhs == 75);
            Assert.AreEqual(true, op.Rhs == 25);
            op = solution[1];
            Assert.AreEqual(350, op.Result);
            Assert.AreEqual(Operator.Multiplication, op.Operator);
            Assert.AreEqual(true, op.Lhs == 50);
            Assert.AreEqual(true, op.Rhs == 7);
            op = solution[2];
            Assert.AreEqual(353, op.Result);
            Assert.AreEqual(Operator.Addition, op.Operator);
            Assert.AreEqual(true, op.Lhs == 350);
            Assert.AreEqual(true, op.Rhs == 3);
        }



    }
}
