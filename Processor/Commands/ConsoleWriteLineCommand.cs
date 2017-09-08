using System;

namespace AutoProcessor.Commands
{
    public class ConsoleWriteLineCommand : ICommand
    {
        private string _message;

        public ConsoleWriteLineCommand(string message)
        {
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine(_message);
        }
    }
}
