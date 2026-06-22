using System;
using System.Threading;

namespace ProxyPatternExample
{
    public class RealImage : IImage
    {
        private readonly string _fileName;

        public RealImage(string fileName)
        {
            _fileName = fileName;
            LoadFromRemoteServer();
        }

        private void LoadFromRemoteServer()
        {
            Console.WriteLine($"RealImage: Loading image '{_fileName}' from remote server...");
            // Simulate network latency / load delay
            Thread.Sleep(1500);
            Console.WriteLine($"RealImage: Image '{_fileName}' loaded successfully.");
        }

        public void Display()
        {
            Console.WriteLine($"RealImage: Displaying image '{_fileName}'.");
        }
    }
}
