using System;
using System.IO;

namespace Codes.day7
{
    public class Runner
    {
        private static int[] _GetIntCodes(string path)
        {
            var fileContent = File.ReadAllText(path);

            var integerStrings = fileContent.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            var integers = new int[integerStrings.Length];

            for (var n = 0; n < integerStrings.Length; n++)
                integers[n] = int.Parse(integerStrings[n]);

            return integers;
        }

        public static double SolveDay2Part1(int arg1, int arg2)
        {
            var program = _GetIntCodes(@"../../../../codes/day2/program.txt");
            var computer = new IntCodeComputer();
            var engine = new ComputeEngine();
            computer.AddEngine(engine);

            var outputProgram = computer.Run(program, arg1, arg2);

            return outputProgram[0];
        }

        public static double SolveDay2Part2(in int target)
        {
            for (var i = 0; i < 99; i++)
            for (var j = 0; j < 99; j++)
                try
                {
                    var computer = new IntCodeComputer();
                    var engine = new ComputeEngine();
                    computer.AddEngine(engine);
                    var output = computer.Run(_GetIntCodes(@"../../../../codes/day2/program.txt"), i, j);
                    if (output[0] == target) return 100 * i + j;
                }
                catch (Exception)
                {
                    // ignored
                }

            return -1;
        }

        public static IntCodeComputer SolveDay5Part1(int input)
        {
            var computer = new IntCodeComputer();
            var program = _GetIntCodes(@"../../../../codes/day5/program.txt");

            var computeEngine = new ComputeEngine();
            computeEngine.InputData.Enqueue(input);

            computer.AddEngine(computeEngine);
            computer.Run(program);

            return computer;
        }

        public static IntCodeComputer SolveDay5Part2(in int input)
        {
            var computer = new IntCodeComputer();
            var program = _GetIntCodes(@"../../../../codes/day5/program.txt");

            var computeEngine = new ComputeEngine();
            computeEngine.InputData.Enqueue(input);

            computer.AddEngine(computeEngine);
            computer.Run(program);

            return computer;
        }

        public static double SolveDay7Part1()
        {
            var program = _GetIntCodes(@"../../../../codes/day7/program.txt");
            return AmplificationCircuit.FindMaxThrust(program, new[] {0, 1, 2, 3, 4});
        }

        public static double SolveDay7Part2()
        {
            var program = _GetIntCodes(@"../../../../codes/day7/program.txt");
            return AmplificationCircuit.FindMaxThrust(program, new[] {5, 6, 7, 8, 9});
        }
    }
}