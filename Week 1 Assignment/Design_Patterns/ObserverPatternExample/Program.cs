using System;

namespace ObserverPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Observer Pattern Example");
            Console.WriteLine("========================================");

            // Create subject
            StockMarket stockMarket = new StockMarket();

            // Create observers
            IObserver mobileApp1 = new MobileApp("iPhone Client");
            IObserver mobileApp2 = new MobileApp("Android Client");
            IObserver webDashboard = new WebApp("Financial Web Portal");

            // Register observers
            Console.WriteLine("\nRegistering observers...");
            stockMarket.RegisterObserver(mobileApp1);
            stockMarket.RegisterObserver(mobileApp2);
            stockMarket.RegisterObserver(webDashboard);

            // Trigger stock updates
            stockMarket.UpdateStockPrice("GOOGL", 175.40);
            stockMarket.UpdateStockPrice("AAPL", 189.95);

            // Deregister an observer
            Console.WriteLine("\nDeregistering Android Client...");
            stockMarket.DeregisterObserver(mobileApp2);

            // Trigger another update
            stockMarket.UpdateStockPrice("MSFT", 420.10);

            Console.WriteLine("\nObserver Pattern demonstration completed.");
        }
    }
}
