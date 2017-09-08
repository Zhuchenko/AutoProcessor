using System.Diagnostics;

namespace AutoProcessor.Commands
{
    public class RunBatFileCommand : ICommand
    {
        private ProcessStartInfo _info;

        public RunBatFileCommand(string path)
        {
            _info = new ProcessStartInfo
            {
                FileName = path,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

        }

        public void Execute()
        {
            Process proccess = new Process
            {
                StartInfo = _info
            };
            proccess.Start();
        }
    }
}
