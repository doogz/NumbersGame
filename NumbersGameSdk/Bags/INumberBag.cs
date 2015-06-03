namespace ScottLogic.NumbersGame.Bags
{
    public interface INumberBag
    {
        string Description { get; }
        int TakeNumber();
        int Count { get; }
        bool IsEmpty { get; }
    }

    interface INumberBags
    {
        int Bags { get; }
        INumberBag Bag(int bag);
    }
}
