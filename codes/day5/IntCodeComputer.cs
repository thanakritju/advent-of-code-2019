using System;
using System.Collections.Generic;

namespace Codes.day5
{
    public partial class IntCodeComputer
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
    }
}