using System;
using System.Diagnostics;

namespace ProxyPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Proxy Pattern Example");
            Console.WriteLine("========================================");

            // Create proxy images
            IImage image1 = new ProxyImage("nature_landscape.jpg");
            IImage image2 = new ProxyImage("family_photo.png");

            // Image 1: First Display (Requires Loading)
            Console.WriteLine("\n--- Displaying Image 1 for the first time ---");
            Stopwatch sw = Stopwatch.StartNew();
            image1.Display();
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            // Image 1: Second Display (Should be Cached)
            Console.WriteLine("\n--- Displaying Image 1 for the second time ---");
            sw.Restart();
            image1.Display();
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms (Expected: 0 ms delay)");

            // Image 2: First Display (Requires Loading)
            Console.WriteLine("\n--- Displaying Image 2 for the first time ---");
            sw.Restart();
            image2.Display();
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            // Image 2: Second Display (Should be Cached)
            Console.WriteLine("\n--- Displaying Image 2 for the second time ---");
            sw.Restart();
            image2.Display();
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            Console.WriteLine("\nProxy Pattern demonstration completed.");
        }
    }
}
