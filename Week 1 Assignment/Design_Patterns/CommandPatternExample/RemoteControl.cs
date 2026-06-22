using System;

namespace CommandPatternExample
{
    public class RemoteControl
    {
        private ICommand _command;

        // Set the active command
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        // Press button to execute the command
        public void PressButton()
        {
            if (_command == null)
            {
                Console.WriteLine("RemoteControl: No command is assigned to this slot.");
                return;
            }
            _command.Execute();
        }
    }
}
