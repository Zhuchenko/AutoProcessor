using System;
using AutoProcessor.Commands;

namespace AutoProcessor.Steps
{
    public class StepWithCondition : Step
    {
        private Step _ifDone;

        public StepWithCondition(ICommand command, Step nextStepIfFailed, Step nextStepIfDone) 
            : base(command, nextStepIfFailed)
        {
            _ifDone = nextStepIfDone;
        }

        public override bool Start()
        {
            try
            {
                _command.Execute();
                NextStep = _ifDone;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
