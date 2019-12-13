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
            }

            throw new Exception("Unidentified Operation Code");
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