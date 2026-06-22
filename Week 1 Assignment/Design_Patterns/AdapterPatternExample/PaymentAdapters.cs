namespace AdapterPatternExample
{
    // Adapter for PayPal
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalGateway _payPalGateway;

        public PayPalAdapter(PayPalGateway payPalGateway)
        {
            _payPalGateway = payPalGateway;
        }

        public void ProcessPayment(double amount)
        {
            // Direct translation
            _payPalGateway.SendPayment(amount);
        }
    }

    // Adapter for Stripe
    public class StripeAdapter : IPaymentProcessor
    {
        private readonly StripeGateway _stripeGateway;

        public StripeAdapter(StripeGateway stripeGateway)
        {
            _stripeGateway = stripeGateway;
        }

        public void ProcessPayment(double amount)
        {
            // Translate amount in dollars to cents as required by Stripe's API
            double cents = amount * 100;
            _stripeGateway.CaptureCharge(cents);
        }
    }
}
