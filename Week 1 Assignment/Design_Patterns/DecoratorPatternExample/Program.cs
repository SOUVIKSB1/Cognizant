using System;

namespace DecoratorPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Decorator Pattern Example");
            Console.WriteLine("========================================");

            string alertMessage = "CRITICAL: Database connection limit exceeded!";

            // 1. Basic Notifier (Email only)
            Console.WriteLine("\n--- Sending via Base Notifier (Email Only) ---");
            INotifier baseNotifier = new EmailNotifier();
            baseNotifier.Send(alertMessage);

            // 2. Email + SMS Notifier
            Console.WriteLine("\n--- Sending via Email + SMS Decorator ---");
            INotifier emailAndSms = new SMSNotifierDecorator(new EmailNotifier());
            emailAndSms.Send(alertMessage);

            // 3. Email + Slack Notifier
            Console.WriteLine("\n--- Sending via Email + Slack Decorator ---");
            INotifier emailAndSlack = new SlackNotifierDecorator(new EmailNotifier());
            emailAndSlack.Send(alertMessage);

            // 4. Fully Decorated: Email + SMS + Slack Notifier
            Console.WriteLine("\n--- Sending via Email + SMS + Slack Decorator ---");
            INotifier fullAlertSystem = new SlackNotifierDecorator(
                new SMSNotifierDecorator(
                    new EmailNotifier()
                )
            );
            fullAlertSystem.Send(alertMessage);

            Console.WriteLine("\nDecorator Pattern demonstration completed.");
        }
    }
}
