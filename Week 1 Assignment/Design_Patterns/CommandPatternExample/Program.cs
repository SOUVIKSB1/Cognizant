using System;

namespace CommandPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Command Pattern Example");
            Console.WriteLine("========================================");

            // 1. Create the receiver
            Light livingRoomLight = new Light("Living Room");

            // 2. Create the concrete commands
            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            // 3. Create the invoker
            RemoteControl remote = new RemoteControl();

            // 4. Test turning the light ON
            Console.WriteLine("\n--- Setting command: Light On ---");
            remote.SetCommand(lightOn);
            remote.PressButton();

            // 5. Test turning the light OFF
            Console.WriteLine("\n--- Setting command: Light Off ---");
            remote.SetCommand(lightOff);
            remote.PressButton();

            // 6. Test with no command configured
            Console.WriteLine("\n--- Setting command to null ---");
            remote.SetCommand(null);
            remote.PressButton();

            Console.WriteLine("\nCommand Pattern demonstration completed.");
        }
    }
}
