using System;
using System.Diagnostics;
using System.Linq;

namespace EcommercePlatformSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("E-commerce Search Benchmarking");
            Console.WriteLine("========================================");

            // 1. Create unsorted array of products
            Product[] products = new Product[]
            {
                new Product("P103", "Sony Headphones", "Electronics"),
                new Product("P101", "Apple MacBook", "Electronics"),
                new Product("P105", "Nike Running Shoes", "Apparel"),
                new Product("P102", "Samsung Galaxy S23", "Electronics"),
                new Product("P104", "Dell Monitor", "Electronics"),
                new Product("P106", "Leather Wallet", "Accessories")
            };

            Console.WriteLine("Unsorted Products:");
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            // 2. Perform Linear Search
            string target = "Dell Monitor";
            Console.WriteLine($"\n--- Linear Search for '{target}' ---");
            int linIndex = SearchAlgorithms.LinearSearch(products, target);
            if (linIndex != -1)
            {
                Console.WriteLine($"Found at index {linIndex}: {products[linIndex]}");
            }
            else
            {
                Console.WriteLine("Not found.");
            }

            // 3. Prepare sorted array for Binary Search
            Console.WriteLine("\nSorting products by Name for Binary Search...");
            Product[] sortedProducts = products.OrderBy(p => p.ProductName).ToArray();

            Console.WriteLine("Sorted Products:");
            foreach (var p in sortedProducts)
            {
                Console.WriteLine(p);
            }

            // 4. Perform Binary Search
            Console.WriteLine($"\n--- Binary Search for '{target}' ---");
            int binIndex = SearchAlgorithms.BinarySearch(sortedProducts, target);
            if (binIndex != -1)
            {
                Console.WriteLine($"Found at index {binIndex} in sorted array: {sortedProducts[binIndex]}");
            }
            else
            {
                Console.WriteLine("Not found.");
            }

            // 5. Benchmark search on larger dataset
            Console.WriteLine("\n--- Performance Benchmarking on 1,000 items ---");
            Product[] largeDataset = new Product[1000];
            for (int i = 0; i < 1000; i++)
            {
                largeDataset[i] = new Product($"P{i:D4}", $"Product {i:D4}", "General");
            }

            // Binary search needs sorted dataset (which it already is by design here: Product 0000 to Product 0999)
            string searchTarget = "Product 0750";

            // Benchmark Linear Search
            Stopwatch sw = Stopwatch.StartNew();
            int lRes = SearchAlgorithms.LinearSearch(largeDataset, searchTarget);
            sw.Stop();
            long linTime = sw.ElapsedTicks;
            Console.WriteLine($"Linear Search Result Index: {lRes} | Time: {linTime} ticks");

            // Benchmark Binary Search
            sw.Restart();
            int bRes = SearchAlgorithms.BinarySearch(largeDataset, searchTarget);
            sw.Stop();
            long binTime = sw.ElapsedTicks;
            Console.WriteLine($"Binary Search Result Index: {bRes} | Time: {binTime} ticks");

            Console.WriteLine($"Binary search was {((double)linTime / (binTime == 0 ? 1 : binTime)):F2}x faster in this test run.");
        }
    }
}
