using System.Collections.Generic;

namespace Codes.day7
{
    public partial class IntCodeComputer
    {
        public IntCodeComputer()
        {
            InputData = new Queue<int>();
            OutputData = new List<int>();
        }

        public Queue<int> InputData { get; }
        public List<int> OutputData { get; }

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