using System;
using AutoProcessor;
using AutoProcessor.Commands;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Builder();

            var positive = builder.BuildStep(TypeOfCommand.WriteLine, "fourth [positive]", null);
            var negative = builder.BuildStep(TypeOfCommand.WriteLine, "fourth [negative]", null);
            var condition = builder.BuildStepWithCondition(TypeOfCommand.WriteLine, "third [condition]", negative, positive);
            var second = builder.BuildStep(TypeOfCommand.WriteLine, "second", condition);
            var first = builder.BuildStep(TypeOfCommand.WriteLine, "first", second);

            var processor = new Processor(first);

            processor.Start();

            Console.ReadKey();
        }
    }
}
