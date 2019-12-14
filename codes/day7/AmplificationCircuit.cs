using System.Collections.Generic;
using System.Linq;

namespace Codes.day7
{
    public class AmplificationCircuit
    {
        public static int FindMaxThrust(int[] program, int[] phaseSetting)
        {
            var settings = GetPermutations(phaseSetting);
            var outputs = new List<int>();
            foreach (var setting in settings)
            {
                var intCodeComputer = new IntCodeComputer();

                intCodeComputer.AddEngine(new ComputeEngine("A"));
                intCodeComputer.AddEngine(new ComputeEngine("B"));
                intCodeComputer.AddEngine(new ComputeEngine("C"));
                intCodeComputer.AddEngine(new ComputeEngine("D"));
                intCodeComputer.AddEngine(new ComputeEngine("E"));
                intCodeComputer.RunMultipleEnginesWithFeedbackLoop(program, setting);
                outputs.Add(intCodeComputer.GetOutputFromEngine());
            }

            return outputs.Max();
        }

        private static IEnumerable<T[]> GetPermutations<T>(T[] values)
        {
            if (values.Length == 1)
                return new[] {values};

            return values.SelectMany(v => GetPermutations(values.Except(new[] {v}).ToArray()),
                (v, p) => new[] {v}.Concat(p).ToArray());
        }
    }
}