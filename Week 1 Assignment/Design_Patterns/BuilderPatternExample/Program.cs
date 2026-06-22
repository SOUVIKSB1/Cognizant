using System;

namespace BuilderPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Builder Pattern Example");
            Console.WriteLine("========================================");

            // 1. Build a high-end Gaming PC
            Console.WriteLine("\nAssembling Gaming PC...");
            Computer gamingPC = new Computer.Builder("Intel Core i9-14900K", "32GB DDR5", "2TB NVMe SSD")
                .SetGPU("NVIDIA GeForce RTX 4090")
                .SetOS("Windows 11 Pro")
                .SetWiFi(true)
                .SetBluetooth(true)
                .Build();

            Console.WriteLine(gamingPC);

            // 2. Build a budget Office PC
            Console.WriteLine("\nAssembling Office PC...");
            Computer officePC = new Computer.Builder("Intel Core i5-13400", "8GB DDR4", "512GB SATA SSD")
                .SetOS("Windows 11 Home")
                // GPU, WiFi, and Bluetooth are left to default (false/null)
                .Build();

            Console.WriteLine(officePC);

            // 3. Build a Server node (no OS pre-installed, no WiFi/GPU)
            Console.WriteLine("\nAssembling Headless Server Node...");
            Computer serverNode = new Computer.Builder("AMD EPYC 9654", "256GB ECC RAM", "8TB Enterprise SSD")
                .Build();

            Console.WriteLine(serverNode);

            Console.WriteLine("\nBuilder Pattern demonstration completed.");
        }
    }
}
