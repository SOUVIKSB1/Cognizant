using System;

namespace ProxyPatternExample
{
    public class ProxyImage : IImage
    {
        private RealImage _realImage;
        private readonly string _fileName;

        public ProxyImage(string fileName)
        {
            _fileName = fileName;
            _realImage = null; // Lazy loading: Real image is not loaded yet
        }

        public void Display()
        {
            // If the image is not loaded, load it (lazy initialization)
            if (_realImage == null)
            {
                Console.WriteLine($"ProxyImage: First time display request. Instantiating RealImage for '{_fileName}'...");
                _realImage = new RealImage(_fileName);
            }
            else
            {
                Console.WriteLine($"ProxyImage: Cache hit! Retaining already loaded RealImage for '{_fileName}'...");
            }

            // Delegate behavior to the real subject
            _realImage.Display();
        }
    }
}
