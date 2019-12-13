using System;
using System.Collections.Generic;
using System.Linq;

namespace Codes.day5
{
    public class IntCodeComputer
    {
        public Queue<int> InputData { get; }
        public List<int> OutputData { get; }
        public IntCodeComputer()
        {
            InputData = new Queue<int>();
            OutputData = new List<int>();
        }

        public int[] Run(int[] program, int arg1, int arg2)
        {
            program[1] = arg1;
            program[2] = arg2;
            return _Run(program, 0);
        }
        

        public int[] Run(int[] program)
        {
            return _Run(program, 0);
        }

        private int[] _Run(int[] program, int index)
        {
            switch (program[index])
            {
                case 99:
                    return program;
                case 1:
                    return _Run(_Add(program, index), index + 4);
                case 2:
                    return _Run(_Multiply(program, index), index + 4);
                case 3:
                    return _Run(_Read(program, index), index + 2);
                case 4:
                    return _Run(_Print(program, index), index + 2);
            }
            throw new Exception("Unidentified Operation Code");
        }

        private static int _GetValue(int[] program, int index, int mode = 0)
        {
            return mode == 0 ? program[program[index]] : program[index];
        }

        private int[] _Print(int[] program, int index)
        {
            OutputData.Add(program[program[index + 1]]);
            return program;
        }

        private int[] _Read(int[] program, int index)
        {
            var i = Convert.ToInt32(InputData.Dequeue());
            program[program[index + 1]] = i;
            return program;
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