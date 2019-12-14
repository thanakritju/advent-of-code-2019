using System;
using System.Collections.Generic;

namespace Codes.day9
{
    public partial class IntCodeComputer
    {
        private long[] _Equals(long[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            var valueToSet = first == second ? 1 : 0;
            _SetValue(program, index + 3, modes[2], valueToSet);
            return program;
        }

        private long[] _LessThan(long[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            var valueToSet = first < second ? 1 : 0;
            _SetValue(program, index + 3, modes[2], valueToSet);
            return program;
        }

        private int _JumpIfFalse(long[] program, int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            return first == 0 ? (int) second : index + 3;
        }

        private int _JumpIfTrue(long[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            return first != 0 ? (int) second : index + 3;
        }

        private long[] _Print(long[] program, int index, List<int> modes)
        {
            OutputData.Enqueue(_GetValue(program, index + 1, modes[0]));
            return program;
        }

        private long[] _Read(long[] program, int index, List<int> modes)
        {
            try{
                var valueToSet = Convert.ToInt32(InputData.Dequeue());
                _SetValue(program, index + 1, modes[0], valueToSet);
                return program;
            }
            catch (InvalidOperationException)
            {
                _savedProgram = program;
                _savedInstruction = index;
                throw new InvalidOperationException("There is no input, waiting for input");
            }
        }

        private long[] _Add(long[] program, int index, List<int> modes)
        {
            var valueToSet = _GetValue(program, index + 1, modes[0]) +
                             _GetValue(program, index + 2, modes[1]);
            _SetValue(program, index + 3, modes[2], valueToSet);
            return program;
        }

        private long[] _Multiply(long[] program, int index, List<int> modes)
        {
            var valueToSet = _GetValue(program, index + 1, modes[0]) *
                             _GetValue(program, index + 2, modes[1]);
            _SetValue(program, index + 3, modes[2], valueToSet);
            return program;
        }

        private long[] _AdjustRelativeBase(long[] program, in int index, List<int> modes)
        {
            _relativeBase += _GetValue(program, index + 1, modes[0]);
            return program;
        }

        private void _SetValue(long[] program, int index, int mode, long valueToSet)
        {
            switch (mode)
            {
                case 0:
                    program[program[index]] = valueToSet;
                    break;
                case 2:
                    program[_relativeBase + program[index]] = valueToSet;
                    break;
            }
        }


        private long _GetValue(long[] program, int index, int mode = 0)
        {
            switch (mode)
            {
                case 0:
                    return program[program[index]];
                case 1:
                    return program[index];
                case 2:
                    return program[_relativeBase + program[index]];
            }

            throw new InvalidOperationException($"Invalid mode {mode}");
        }
    }
}