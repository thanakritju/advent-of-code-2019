using System;
using System.Collections.Generic;

namespace Codes.day5
{
    public partial class IntCodeComputer
    {
        private int[] _Run(int[] program, int index)
        {
            var preParseOpcode = program[index];
            var (opcode, modes) = _ParseOperationCode(preParseOpcode);
            switch (opcode)
            {
                case 99:
                    return program;
                case 1:
                    return _Run(_Add(program, index, modes), index + 4);
                case 2:
                    return _Run(_Multiply(program, index, modes), index + 4);
                case 3:
                    return _Run(_Read(program, index), index + 2);
                case 4:
                    return _Run(_Print(program, index, modes), index + 2);
                case 5:
                    return _Run(program, _JumpIfTrue(program, index, modes));
                case 6:
                    return _Run(program, _JumpIfFalse(program, index, modes));
                case 7:
                    return _Run(_LessThan(program, index, modes), index + 4);
                case 8:
                    return _Run(_Equals(program, index, modes), index + 4);
            }

            throw new Exception($"Unidentified Operation Code: {opcode}");
        }

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

        private static Tuple<int, List<int>> _ParseOperationCode(int opcode)
        {
            var modes = new List<int>();
            if (opcode > 99)
            {
                modes.Add(opcode/100%10);
                modes.Add(opcode/1000);
                opcode %= 100;
            }
            else
            {
                modes.Add(0);
                modes.Add(0);
            }
            return Tuple.Create(opcode, modes);
        }

        private static int _GetValue(int[] program, int index, int mode = 0)
        {
            return mode == 0 ? program[program[index]] : program[index];
        }

        private int[] _Print(int[] program, int index, List<int> modes)
        {
            OutputData.Add(_GetValue(program, index + 1, modes[0]));
            return program;
        }

        private int[] _Read(int[] program, int index)
        {
            var i = Convert.ToInt32(InputData.Dequeue());
            program[program[index + 1]] = i;
            return program;
        }

        private static int[] _Add(int[] program, int index, List<int> modes)
        {
            program[program[index + 3]] = _GetValue(program, index + 1, modes[0]) + 
                                          _GetValue(program, index + 2, modes[1]);
            return program;
        }

        private static int[] _Multiply(int[] program, int index, List<int> modes)
        {
            program[program[index + 3]] = _GetValue(program, index + 1, modes[0]) * 
                                          _GetValue(program, index + 2, modes[1]);
            return program;
        }
    }
}