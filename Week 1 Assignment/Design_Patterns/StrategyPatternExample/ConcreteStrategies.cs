using System;

namespace StrategyPatternExample
{
    // Concrete Strategy 1: Credit Card Payment
    public class CreditCardPayment : IPaymentStrategy
    {
        private readonly string _cardHolderName;
        private readonly string _cardNumber;
        private readonly string _cvv;

        public CreditCardPayment(string cardHolderName, string cardNumber, string cvv)
        {
            _cardHolderName = cardHolderName;
            _cardNumber = cardNumber;
            _cvv = cvv;
        }

        public void Pay(double amount)
        {
            // Mask card number for security display
            string maskedCard = _cardNumber.Length > 4 ? $"XXXX-XXXX-XXXX-{_cardNumber.Substring(_cardNumber.Length - 4)}" : _cardNumber;
            Console.WriteLine($"Paid ${amount:F2} using Credit Card (Holder: {_cardHolderName}, Card: {maskedCard}).");
        }
    }

    // Concrete Strategy 2: PayPal Payment
    public class PayPalPayment : IPaymentStrategy
    {
        private readonly string _emailAddress;

        public PayPalPayment(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ${amount:F2} using PayPal (Account Email: {_emailAddress}).");
        }
    }
}
