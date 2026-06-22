using System;

namespace AdapterPatternExample
{
    // Adaptee 1: PayPal Gateway
    public class PayPalGateway
    {
        public void SendPayment(double amountInUSD)
        {
            Console.WriteLine($"PayPal: Processing transaction of ${amountInUSD:F2} USD.");
        }
    }

    // Adaptee 2: Stripe Gateway
    public class StripeGateway
    {
        public void CaptureCharge(double amountInCents)
        {
            Console.WriteLine($"Stripe: Capturing credit card charge of {amountInCents:F0} cents.");
        }
    }
}
