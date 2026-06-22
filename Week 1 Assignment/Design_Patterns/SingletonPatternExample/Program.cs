using System;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Singleton Pattern Example");
            Console.WriteLine("========================================");

            // Access the Logger instance for the first time
            Console.WriteLine("Accessing Logger.Instance for the first time (l1)...");
            Logger l1 = Logger.Instance;
            l1.Log("First log message from l1.");

            // Access the Logger instance again
            Console.WriteLine("\nAccessing Logger.Instance again (l2)...");
            Logger l2 = Logger.Instance;
            l2.Log("Second log message from l2.");

            // Verify both references point to the same instance in memory
            Console.WriteLine("\nVerifying instance identity...");
            bool areEqual = ReferenceEquals(l1, l2);
            Console.WriteLine($"Are l1 and l2 the exact same instance? {areEqual}");

            if (areEqual)
            {
                Console.WriteLine("SUCCESS: Singleton pattern successfully verified! Only one instance exists.");
            }
            else
            {
                Console.WriteLine("FAILURE: Singleton pattern failed. Multiple instances were created.");
            }
        }
    }
}
