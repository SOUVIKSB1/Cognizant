using System;

namespace StrategyPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Strategy Pattern Example");
            Console.WriteLine("========================================");

            double orderAmount1 = 250.00;
            double orderAmount2 = 89.95;

            // 1. Initial Strategy: Credit Card Payment
            Console.WriteLine("\n--- Setting Strategy: Credit Card ---");
            IPaymentStrategy creditCard = new CreditCardPayment("Souvik Sen", "1234567890123456", "123");
            PaymentContext context = new PaymentContext(creditCard);

            Console.WriteLine($"Paying order 1 (${orderAmount1:F2})...");
            context.ExecutePayment(orderAmount1);

            // 2. Change Strategy at Runtime to PayPal
            Console.WriteLine("\n--- Swapping Strategy: PayPal ---");
            IPaymentStrategy payPal = new PayPalPayment("souvik.sen@example.com");
            context.SetPaymentStrategy(payPal);

            Console.WriteLine($"Paying order 2 (${orderAmount2:F2})...");
            context.ExecutePayment(orderAmount2);

            Console.WriteLine("\nStrategy Pattern demonstration completed.");
        }
    }
}
