using System.Collections.Generic;
using System.Linq;
using AutoProcessor.Steps;

namespace AutoProcessor
{
    public class Checker
    {
        public Checker(IEnumerable<Step> dependency)
        {
            Dependency = dependency.ToList() ?? new List<Step>();
        }

        public List<Step> Dependency { get; private set; }

        public bool Check(IEnumerable<StepStatusPair> all)
        {
            foreach(var step in Dependency)
            {
                bool isOK = false;

                foreach(var stepWithStatus in all)
                {
                    if(stepWithStatus.Step == step)
                    {
                        if (stepWithStatus.IsFinished)
                        {
                            isOK = true;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                if(!isOK)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
