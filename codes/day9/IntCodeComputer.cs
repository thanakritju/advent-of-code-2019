using System.Collections.Generic;
using System.Linq;

namespace Codes.day9
{
    public partial class IntCodeComputer
    {
        private long _relativeBase;

        public IntCodeComputer()
        {
            InputData = new Queue<int>();
            OutputData = new List<long>();
            _relativeBase = 0;
        }

        public Queue<int> InputData { get; }
        public List<long> OutputData { get; }

        public long[] Run(long[] program, int arg1, int arg2)
        {
            program[1] = arg1;
            program[2] = arg2;
            return _Run(program, 0);
        }
        
        public long[] Run(long[] program)
        {
            return _Run(program, 0);
        }
        
        public long[] Run(int[] program)
        {
            
            return _Run(program.Select(item => (long)item).ToArray(), 0);
        }
    }
}