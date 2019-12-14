using System.Collections.Generic;
using System.Linq;

namespace Codes.day7
{
    public class AmplificationCircuit
    {
        public static int FindMaxThrust(int[] program, int[] phaseSetting)
        {
            var permutations = GetPermutations(phaseSetting);
            var outputs = new List<int>();
            foreach (var setting in permutations)
            {
                var intCodeComputer = new IntCodeComputer();
                foreach (var _ in setting) intCodeComputer.AddEngine(new ComputeEngine());
                intCodeComputer.RunMultipleEngines(program, setting);
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