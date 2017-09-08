using AutoProcessor.Steps;
using System.Collections.Generic;

namespace AutoProcessor
{
    public class Processor
    {
        private Step _startStep;
        private List<StepStatusPair> _all;

        public Processor(Step start)
        {
            _startStep = start;
            _all = new List<StepStatusPair>();
        }

        public void Start()
        {
            var currentStep = _startStep;

            while (currentStep != null)
            {
                var canStart = currentStep.Dependency.Check(_all);
                var done = false;

                if (canStart)
                {
                    done = currentStep.Start();
                }

                _all.Add(new StepStatusPair(currentStep, done));

                currentStep = currentStep.NextStep;
            }
        }
    }
}
