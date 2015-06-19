namespace ScottLogic.NumbersGame
{
    /// <summary>
    /// IOperation represents the combination of two numbers with an appropriate operator to yield a result.
    /// Each operation consumes two numbers and generates a new one.
    /// </summary>
    public interface IOperation
    {
        int Lhs { get; }
        Operator Operator { get; }
        int Rhs { get; }
        int Result { get; }
        string DisplayString { get; }
    }
}
