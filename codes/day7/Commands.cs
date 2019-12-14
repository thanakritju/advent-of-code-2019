using System;
using System.Collections.Generic;

namespace Codes.day7
{
    public partial class ComputeEngine
    {
        private int[] _Equals(in int[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            program[program[index + 3]] = first == second ? 1 : 0;
            return program;
        }

        private int[] _LessThan(in int[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            program[program[index + 3]] = first < second ? 1 : 0;
            return program;
        }

        private int _JumpIfFalse(in int[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            return first == 0 ? second : index + 3;
        }

        private int _JumpIfTrue(in int[] program, in int index, List<int> modes)
        {
            var first = _GetValue(program, index + 1, modes[0]);
            var second = _GetValue(program, index + 2, modes[1]);
            return first != 0 ? second : index + 3;
        }

        private int[] _Print(in int[] program, in int index, List<int> modes)
        {
            OutputData.Add(_GetValue(program, index + 1, modes[0]));
            return program;
        }

        private int[] _Read(in int[] program, in int index)
        {
            try
            {
                var i = Convert.ToInt32(InputData.Dequeue());
                program[program[index + 1]] = i;
                return program;
            }
            catch (InvalidOperationException)
            {
                _savedProgram = program;
                _savedInstruction = index;
                throw new InvalidOperationException("There is no input, waiting for input");
            }
        }

        private static int[] _Add(in int[] program, in int index, List<int> modes)
        {
            program[program[index + 3]] = _GetValue(program, index + 1, modes[0]) +
                                          _GetValue(program, index + 2, modes[1]);
            return program;
        }

        private static int[] _Multiply(in int[] program, in int index, List<int> modes)
        {
            program[program[index + 3]] = _GetValue(program, index + 1, modes[0]) *
                                          _GetValue(program, index + 2, modes[1]);
            return program;
        }
    }
}