using System;

namespace AdapterPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Adapter Pattern Example");
            Console.WriteLine("========================================");

            // Client requires transactions in double amount (dollars)
            double purchaseAmount = 149.99;

            // 1. Process payment via PayPal
            Console.WriteLine($"\nProcessing payment of ${purchaseAmount:F2} via PayPal...");
            PayPalGateway payPalGateway = new PayPalGateway();
            IPaymentProcessor payPalProcessor = new PayPalAdapter(payPalGateway);
            payPalProcessor.ProcessPayment(purchaseAmount);

            // 2. Process payment via Stripe
            Console.WriteLine($"\nProcessing payment of ${purchaseAmount:F2} via Stripe...");
            StripeGateway stripeGateway = new StripeGateway();
            IPaymentProcessor stripeProcessor = new StripeAdapter(stripeGateway);
            stripeProcessor.ProcessPayment(purchaseAmount);

            Console.WriteLine("\nAdapter Pattern demonstration completed.");
        }
    }
}
