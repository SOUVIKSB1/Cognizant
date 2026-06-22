using System;

namespace ObserverPatternExample
{
    // Concrete Observer 1: Mobile App
    public class MobileApp : IObserver
    {
        public string ObserverName { get; }

        public MobileApp(string appName)
        {
            ObserverName = appName;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine($"[Mobile App - {ObserverName}]: Push Notification - '{stockName}' is now ${price:F2}.");
        }
    }

    // Concrete Observer 2: Web App
    public class WebApp : IObserver
    {
        public string ObserverName { get; }

        public WebApp(string appName)
        {
            ObserverName = appName;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine($"[Web Portal - {ObserverName}]: UI Dashboard updated - '{stockName}' ticker shows ${price:F2}.");
        }
    }
}
