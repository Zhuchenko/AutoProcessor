using System;
using AutoProcessor.Steps;
using AutoProcessor.Commands;

namespace AutoProcessor
{
    public class Builder
    {
        public Step BuildStep(TypeOfCommand type, string options, Step nextStep)
        {
            var command = BuildCommand(type, options);
            
            return new Step(command, nextStep);
        }

        public StepWithCondition BuildStepWithCondition(TypeOfCommand type, string options, 
            Step nextIfFailed, Step nextIfDone)
        {
            var command = BuildCommand(type, options);
            
            return new StepWithCondition(command, nextIfFailed, nextIfDone);
        }

        private ICommand BuildCommand(TypeOfCommand type, string options)
        {
            ICommand command;
            switch (type)
            {
                case TypeOfCommand.CMD:
                    command = new CMDCommand(options);
                    break;
                case TypeOfCommand.WriteLine:
                    command = new ConsoleWriteLineCommand(options);
                    break;
                case TypeOfCommand.BatFile:
                    command = new RunBatFileCommand(options);
                    break;
                default:
                    throw new ArgumentException();
            }

            return command;
        }
    }
}
