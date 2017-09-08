using System;
using System.Diagnostics;

namespace AutoProcessor.Commands
{
    public class CMDCommand : ICommand
    {
        private ProcessStartInfo _info;

        public CMDCommand(string command)
        {
            _info = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + command,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }

        public void Execute()
        {
            var process = new Process
            {
                StartInfo = _info
            };

            process.Start();
        }
    }
}
