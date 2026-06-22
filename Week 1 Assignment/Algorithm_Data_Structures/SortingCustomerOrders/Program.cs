using System;
using System.Diagnostics;

namespace SortingCustomerOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Sorting Customer Orders Benchmarking");
            Console.WriteLine("========================================");

            // 1. Initialize Order Data
            Order[] ordersForBubble = new Order[]
            {
                new Order("O001", "Alice", 250.50),
                new Order("O002", "Bob", 120.00),
                new Order("O003", "Charlie", 450.75),
                new Order("O004", "Diana", 80.20),
                new Order("O005", "Ethan", 310.00)
            };

            Order[] ordersForQuick = new Order[ordersForBubble.Length];
            Array.Copy(ordersForBubble, ordersForQuick, ordersForBubble.Length);

            Console.WriteLine("Original Orders:");
            foreach (var o in ordersForBubble)
            {
                Console.WriteLine(o);
            }

            // 2. Test Bubble Sort
            Console.WriteLine("\n--- Running Bubble Sort ---");
            SortingAlgorithms.BubbleSort(ordersForBubble);
            foreach (var o in ordersForBubble)
            {
                Console.WriteLine(o);
            }

            // 3. Test Quick Sort
            Console.WriteLine("\n--- Running Quick Sort ---");
            SortingAlgorithms.QuickSort(ordersForQuick);
            foreach (var o in ordersForQuick)
            {
                Console.WriteLine(o);
            }

            // 4. Benchmarking on larger dataset
            Console.WriteLine("\n--- Benchmarking on 500 random orders ---");
            Random rand = new Random(42);
            Order[] bubbleLarge = new Order[500];
            for (int i = 0; i < 500; i++)
            {
                bubbleLarge[i] = new Order($"O{i:D3}", $"Customer {i}", rand.NextDouble() * 1000);
            }

            Order[] quickLarge = new Order[bubbleLarge.Length];
            Array.Copy(bubbleLarge, quickLarge, bubbleLarge.Length);

            // Bubble Sort Time
            Stopwatch sw = Stopwatch.StartNew();
            SortingAlgorithms.BubbleSort(bubbleLarge);
            sw.Stop();
            long bubbleTime = sw.ElapsedTicks;
            Console.WriteLine($"Bubble Sort Time: {bubbleTime} ticks");

            // Quick Sort Time
            sw.Restart();
            SortingAlgorithms.QuickSort(quickLarge);
            sw.Stop();
            long quickTime = sw.ElapsedTicks;
            Console.WriteLine($"Quick Sort Time: {quickTime} ticks");

            Console.WriteLine($"Quick Sort was {((double)bubbleTime / (quickTime == 0 ? 1 : quickTime)):F2}x faster in this test.");
        }
    }
}
