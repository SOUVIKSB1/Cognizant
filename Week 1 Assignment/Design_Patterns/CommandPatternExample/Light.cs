using System;

namespace CommandPatternExample
{
    public class Light
    {
        public string Location { get; }

        public Light(string location)
        {
            Location = location;
        }

        public void TurnOn()
        {
            Console.WriteLine($"[Light - {Location}]: The light is ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine($"[Light - {Location}]: The light is OFF.");
        }
    }
}
