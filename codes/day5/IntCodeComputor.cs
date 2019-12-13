using System;

namespace Codes.day5
{
    public class IntCodeComputor
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
    }
}