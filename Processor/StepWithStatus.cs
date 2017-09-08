using AutoProcessor.Steps;
using System;

namespace AutoProcessor
{
    public class StepStatusPair
    {
        public StepStatusPair(Step step, bool isFinished)
        {
            Step = step;
            IsFinished = isFinished;
        }

        public Step Step { get; }

        public bool IsFinished { get; }
    }
}
