using System;
using System.IO;
using System.Linq;

namespace Codes.day9
{
    public class Runner
    {
        public static long[] GetIntCodes(string path)
        {
            var fileContent = File.ReadAllText(path);

            var integerStrings = fileContent.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            var integers = new long[integerStrings.Length];

            for (var n = 0; n < integerStrings.Length; n++)
                integers[n] = long.Parse(integerStrings[n]);

            return integers;
        }

        public static double SolveDay2Part1(int arg1, int arg2)
        {
            var program = GetIntCodes(@"../../../../codes/day2/program.txt");
            var computer = new IntCodeComputer();

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
                    var output = computer.Run(GetIntCodes(@"../../../../codes/day2/program.txt"), i, j);
                    if (output[0] == target) return 100 * i + j;
                }
                catch (Exception)
                {
                }

            return -1;
        }

        public static IntCodeComputer SolveDay5Part1(int input)
        {
            var computer = new IntCodeComputer();
            var program = GetIntCodes(@"../../../../codes/day5/program.txt");
            computer.InputData.Enqueue(input);
            computer.Run(program);

            return computer;
        }

        public static IntCodeComputer SolveDay5Part2(in int input)
        {
            var computer = new IntCodeComputer();
            var program = GetIntCodes(@"../../../../codes/day5/program.txt");
            computer.InputData.Enqueue(input);
            computer.Run(program);

            return computer;
        }

        public static long SolveDay9Part1(in int input)
        {
            var computer = new IntCodeComputer();
            var program = GetIntCodes(@"../../../../codes/day9/program.txt");
            computer.InputData.Enqueue(input);
            computer.Run(program);

            return computer.OutputData.Last();
        }
    }
}