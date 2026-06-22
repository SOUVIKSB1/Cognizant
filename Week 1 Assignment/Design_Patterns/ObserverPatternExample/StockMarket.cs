using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    public class StockMarket : IStock
    {
        private readonly List<IObserver> _observers;
        private string _stockName;
        private double _price;

        public StockMarket()
        {
            _observers = new List<IObserver>();
        }

        // Register Observer
        public void RegisterObserver(IObserver observer)
        {
            if (observer == null) return;
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                Console.WriteLine($"[StockMarket]: Registered observer '{observer.ObserverName}'.");
            }
        }

        // Deregister Observer
        public void DeregisterObserver(IObserver observer)
        {
            if (observer == null) return;
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
                Console.WriteLine($"[StockMarket]: Deregistered observer '{observer.ObserverName}'.");
            }
        }

        // Notify all registered observers
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_stockName, _price);
            }
        }

        // Update Stock Price and trigger notification
        public void UpdateStockPrice(string stockName, double price)
        {
            _stockName = stockName;
            _price = price;
            Console.WriteLine($"\n[StockMarket]: Stock '{_stockName}' changed to ${_price:F2}. Notifying observers...");
            NotifyObservers();
        }
    }
}
