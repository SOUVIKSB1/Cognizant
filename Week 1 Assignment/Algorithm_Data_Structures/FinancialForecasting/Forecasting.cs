namespace FinancialForecasting
{
    public static class Forecasting
    {
        // Recursive implementation of Future Value calculation
        // Formula: FV = PV * (1 + r)^n
        // Recursive formula: FV(n) = FV(n-1) * (1 + r)
        public static double CalculateFutureValueRecursive(double presentValue, double growthRate, int periods)
        {
            // Base Case: If no periods are left, the future value is the present value.
            if (periods <= 0)
            {
                return presentValue;
            }

            // Recursive Step
            return CalculateFutureValueRecursive(presentValue, growthRate, periods - 1) * (1 + growthRate);
        }

        // Optimized Iterative implementation to avoid recursion overhead
        // Time Complexity: O(n) | Space Complexity: O(1)
        public static double CalculateFutureValueIterative(double presentValue, double growthRate, int periods)
        {
            double futureValue = presentValue;
            double factor = 1 + growthRate;

            for (int i = 0; i < periods; i++)
            {
                futureValue *= factor;
            }

            return futureValue;
        }
    }
}
