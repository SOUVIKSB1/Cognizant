using System;

namespace DecoratorPatternExample
{
    // Abstract Decorator
    public abstract class NotifierDecorator : INotifier
    {
        protected readonly INotifier WrappedNotifier;

        protected NotifierDecorator(INotifier notifier)
        {
            WrappedNotifier = notifier;
        }

        public virtual void Send(string message)
        {
            WrappedNotifier.Send(message);
        }
    }

    // Concrete Decorator 1: SMS
    public class SMSNotifierDecorator : NotifierDecorator
    {
        public SMSNotifierDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            SendSMS(message);
        }

        private void SendSMS(string message)
        {
            Console.WriteLine($"Sending SMS: \"{message}\" to registered phone number.");
        }
    }

    // Concrete Decorator 2: Slack
    public class SlackNotifierDecorator : NotifierDecorator
    {
        public SlackNotifierDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            SendSlack(message);
        }

        private void SendSlack(string message)
        {
            Console.WriteLine($"Sending Slack message: \"{message}\" to channel #alerts.");
        }
    }
}
