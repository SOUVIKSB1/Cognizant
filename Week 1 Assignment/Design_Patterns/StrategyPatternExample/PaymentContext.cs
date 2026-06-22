using System;

namespace StrategyPatternExample
{
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        // Allow setting strategy via constructor
        public PaymentContext(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Allow changing strategy at runtime
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Execute payment strategy
        public void ExecutePayment(double amount)
        {
            if (_paymentStrategy == null)
            {
                Console.WriteLine("Error: Payment strategy is not set.");
                return;
            }
            _paymentStrategy.Pay(amount);
        }
    }
}
