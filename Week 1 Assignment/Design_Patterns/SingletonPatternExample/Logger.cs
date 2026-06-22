using System;

namespace SingletonPatternExample
{
    public sealed class Logger
    {
        // Use Lazy<T> to ensure thread-safe, lazy initialization of the Singleton instance
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        // Private constructor prevents instantiation from outside
        private Logger()
        {
            Console.WriteLine("Logger Instance Initialized (Private Constructor Called).");
        }

        // Public static property to access the single instance
        public static Logger Instance => _instance.Value;

        // Logging method
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] LOG: {message}");
        }
    }
}
