using System;
using System.Collections.Generic;

namespace Codes.day7
{
    public partial class ComputeEngine
    {
        private int[] _Equals(int[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            program[program[index + 3]] = first == second ? 1 : 0;
            return program;
        }

        private int[] _LessThan(int[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            program[program[index + 3]] = first < second ? 1 : 0;
            return program;
        }

        private int _JumpIfFalse(int[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            return first == 0 ? second : index + 3;
        }

        private int _JumpIfTrue(int[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            return first != 0 ? second : index + 3;
        }

        private int[] _Print(int[] program, in int index, List<int> modes)
        {
            OutputData.Add(_GetValue(program, index + 1, modes[0]));
            return program;
        }

        private int[] _Read(int[] program, in int index)
        {
            var i = Convert.ToInt32(InputData.Dequeue());
            program[program[index + 1]] = i;
            return program;
        }

        private static int[] _Add(int[] program, in int index, List<int> modes)
        {
            program[program[index + 3]] = _GetValue(program, index + 1, modes[0]) +
                                          _GetValue(program, index + 2, modes[1]);
            return program;
        }

        private static int[] _Multiply(int[] program, in int index, List<int> modes)
        {
            program[program[index + 3]] = _GetValue(program, index + 1, modes[0]) *
                                          _GetValue(program, index + 2, modes[1]);
            return program;
        }
    }
}