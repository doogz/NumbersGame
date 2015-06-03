using System.Configuration;
using Microsoft.SqlServer.Server;
using ScottLogic.NumbersGame;

namespace SpeedFreak.NumberCrunch
{
    struct LinkedOperation : IOperation
    {
        public int Lhs { get; private set; }

        public Operator Operator { get; private set; }
    
        public int Rhs { get; private set; }

        public int Result { get; private set; }

        public IOperation Parent { get; private set; }

        public string DisplayString
        {
            get
            {
                return System.String.Format("{0} {1} {2} = {3}",
                    Lhs, Operator, Rhs, Result);
            }
        }

        public LinkedOperation(int lhs, Operator op, int rhs)
            :this()
        {
            Lhs = lhs;
            Operator = op;
            Rhs = rhs;
            Result = Operation.Apply(lhs, rhs, op);
        }

        public LinkedOperation(IOperation parent, int lhs, Operator op, int rhs)
            :this(lhs, op, rhs)
        {
            Parent = parent;
        }
    }
}
