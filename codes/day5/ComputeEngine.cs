using System;
using System.Collections.Generic;

namespace Codes.day5
{
    public partial class IntCodeComputer
    {
        private int[] _Run(int[] program, int index)
        {
            var preParseOpCode = program[index];
            var (opCode, modes) = _ParseOperationCode(preParseOpCode);
            switch (opCode)
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

            throw new Exception($"Unidentified Operation Code: {opCode}");
        }

        private static Tuple<int, List<int>> _ParseOperationCode(int opCode)
        {
            var modes = new List<int>();
            if (opCode > 99)
            {
                modes.Add(opCode / 100 % 10);
                modes.Add(opCode / 1000);
                opCode %= 100;
            }
            else
            {
                modes.Add(0);
                modes.Add(0);
            }

            return Tuple.Create(opCode, modes);
        }

        private static int _GetValue(int[] program, int index, int mode = 0)
        {
            return mode == 0 ? program[program[index]] : program[index];
        }
    }
}