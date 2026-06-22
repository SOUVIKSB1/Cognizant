using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Financial Forecasting Test");
            Console.WriteLine("========================================");

            double presentValue = 1000.00; // Initial Investment
            double annualGrowthRate = 0.05; // 5% growth rate
            int years = 10; // Number of periods

            Console.WriteLine($"Initial Investment (PV): ${presentValue:F2}");
            Console.WriteLine($"Annual Growth Rate (r): {annualGrowthRate * 100}%");
            Console.WriteLine($"Forecasting Horizon: {years} years");

            // 1. Recursive calculation
            double fvRecursive = Forecasting.CalculateFutureValueRecursive(presentValue, annualGrowthRate, years);
            Console.WriteLine($"\nRecursive Forecasted Value: ${fvRecursive:F2}");

            // 2. Iterative calculation
            double fvIterative = Forecasting.CalculateFutureValueIterative(presentValue, annualGrowthRate, years);
            Console.WriteLine($"Iterative Forecasted Value: ${fvIterative:F2}");

            // Verify they yield the same result
            if (Math.Abs(fvRecursive - fvIterative) < 0.0001)
            {
                Console.WriteLine("\nSuccess: Both implementations yielded matching values.");
            }
            else
            {
                Console.WriteLine("\nWarning: Implementations resulted in different values.");
            }

            // Demonstrating growth progression
            Console.WriteLine("\nYear-by-Year Progression:");
            for (int y = 1; y <= years; y++)
            {
                double val = Forecasting.CalculateFutureValueIterative(presentValue, annualGrowthRate, y);
                Console.WriteLine($"Year {y:D2}: ${val:F2}");
            }
        }
    }
}
