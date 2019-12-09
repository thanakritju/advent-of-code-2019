using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Codes.day2
{
    public class ProgramAlarm
    {
        public static int[] Run(int[] program, int arg1, int arg2)
        {
            program[1] = arg1;
            program[2] = arg2;
            return Run(program);
        }
        
        public static int[] Run(int[] program)
        {
            return _Run(program, 0);
        }

        private static int[] _Run(int[] program, int index)
        {
            switch (program[index])
            {
                case 99:
                    return program;
                case 1:
                    return _Run(_Add(program, index), index + 4);
                case 2:
                    return _Run(_Multiply(program, index), index + 4);
            }
            throw new Exception("Unidentified Operation Code");
        }

        private static int _GetValue(int[] program, int index, int mode = 0)
        {
            return mode == 0 ? program[program[index]] : program[index];
        }
        
        private static int[] _Add(int[] program, int index)
        {
            program[program[index + 3]] = _GetValue(program, index + 1) + _GetValue(program, index + 2);
            return program;
        }
        
        private static int[] _Multiply(int[] program, int index)
        {
            program[program[index + 3]] = _GetValue(program, index + 1) * _GetValue(program, index + 2);
            return program;
        }

        public static int SolvePart1(int arg1, int arg2)
        {
            var program = _GetIntCodes();

            var outputProgram = Run(program, arg1, arg2);

            return outputProgram[0];
        }
        
        public static int SolvePart2(int target)
        {
            for (var i = 0; i < 99; i++)
            {
                for (var j = 0; j < 99; j++)
                {
                    try
                    {
                        var output = Run(_GetIntCodes(), i, j);
                        if (output[0] == target)
                        {
                            return 100 * i + j;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return -1;
        }

        private static int[] _GetIntCodes()
        {
            string fileContent = File.ReadAllText(@"../../../../codes/day2/program.txt");

            string[] integerStrings = fileContent.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int[] integers = new int[integerStrings.Length];

            for (int n = 0; n < integerStrings.Length; n++)
                integers[n] = int.Parse(integerStrings[n]);

            return integers;
        }
    }
}