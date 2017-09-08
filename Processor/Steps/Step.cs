using AutoProcessor.Commands;
using System;

namespace AutoProcessor.Steps
{
    public class Step
    {
        protected ICommand _command;

        public Step(ICommand command, Step nextStep)
        { 
            _command = command;
            NextStep = nextStep;
            Dependency = new Checker(new Step[0]);
        }

        public Checker Dependency { get; private set; }

        public Step NextStep { get; protected set; }
   
        public virtual bool Start()
        {
            try
            {
                _command.Execute();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SetChecker(Checker checker)
        {
            Dependency = checker;
        }
    }
}
