using System;
using System.Collections.Generic;
using System.Linq;

namespace Codes.day9
{
    public partial class IntCodeComputer
    {
        private long _relativeBase;
        private long[] _savedProgram;
        private int _savedInstruction;

        public IntCodeComputer()
        {
            InputData = new Queue<int>();
            OutputData = new Queue<long>();
            _relativeBase = 0;
            IsHalted = false;
        }

        public Queue<int> InputData { get; }
        public Queue<long> OutputData { get; }
        public bool IsHalted { get; private set; }

        public long[] Run(long[] program, int arg1, int arg2)
        {
            program[1] = arg1;
            program[2] = arg2;
            return _Run(program, 0);
        }

        public void Run(long[] program)
        {
            try
            {
                _Run(program, 0);
            }
            catch (InvalidOperationException)
            {
                // Ignore
            }
        }

        public long[] Run(int[] program)
        {
            return _Run(program.Select(item => (long) item).ToArray(), 0);
        }

        public void AddInput(int input)
        {
            InputData.Enqueue(input);
        }
        
        public long GetOutput()
        {
            return OutputData.Dequeue();
        }
        public void Continue()
        {
            try
            {
                _Run(_savedProgram, _savedInstruction);
            }
            catch (InvalidOperationException)
            {
                //Ignore
            }
        }
    }
}