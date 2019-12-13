using System;
using System.IO;

namespace Codes.day5
{
    public class Runner
    {
        public static int SolvePart1(int arg1, int arg2)
        {
            var program = _GetIntCodes();

            var outputProgram = IntCodeComputor.Run(program, arg1, arg2);

            return outputProgram[0];
        }

        public static int SolvePart2(int target)
        {
            for (var i = 0; i < 99; i++)
            for (var j = 0; j < 99; j++)
                try
                {
                    var output = IntCodeComputor.Run(_GetIntCodes(), i, j);
                    if (output[0] == target) return 100 * i + j;
                }
                catch (Exception)
                {
                    // ignored
                }

            return -1;
        }

        private static int[] _GetIntCodes()
        {
            var fileContent = File.ReadAllText(@"../../../../codes/day2/program.txt");

            var integerStrings = fileContent.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            var integers = new int[integerStrings.Length];

            for (var n = 0; n < integerStrings.Length; n++)
                integers[n] = int.Parse(integerStrings[n]);

            return integers;
        }
    }
}