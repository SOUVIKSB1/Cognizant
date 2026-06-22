namespace ObserverPatternExample
{
    public interface IObserver
    {
        void Update(string stockName, double price);
        string ObserverName { get; }
    }
}
