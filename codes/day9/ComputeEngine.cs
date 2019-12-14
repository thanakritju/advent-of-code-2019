using System;
using System.Collections.Generic;

namespace Codes.day9
{
    public partial class IntCodeComputer
    {
        private long[] _Run(long[] inputProgram, int index)
        {
            var program = new long[inputProgram.Length];
            inputProgram.CopyTo(program, 0);

            var preParseOpCode = program[index];
            var (opCode, modes) = _ParseOperationCode(preParseOpCode);
            try
            {
                switch (opCode)
                {
                    case 99:
                        return program;
                    case 1:
                        return _Run(_Add(program, index, modes), index + 4);
                    case 2:
                        return _Run(_Multiply(program, index, modes), index + 4);
                    case 3:
                        return _Run(_Read(program, index, modes), index + 2);
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
                    case 9:
                        return _Run(_AdjustRelativeBase(program, index, modes), index + 2);
                }
            }
            catch (IndexOutOfRangeException)
            {
                return _Run(_AllocateMoreMemory(program), index);
            }

            throw new Exception($"Unidentified Operation Code: {opCode}");
        }

        private long[] _AllocateMoreMemory(long[] program)
        {
            var newProgram = new long[program.Length * 2];
            program.CopyTo(newProgram, 0);
            return newProgram;
        }

        private static Tuple<int, List<int>> _ParseOperationCode(long opCode)
        {
            var modes = new List<int>();
            if (opCode > 99)
            {
                modes.Add((int) (opCode / 100 % 10));
                modes.Add((int) (opCode / 1000 % 10));
                modes.Add((int) (opCode / 10000));
                opCode %= 100;
            }
            else
            {
                modes.Add(0);
                modes.Add(0);
                modes.Add(0);
            }

            return Tuple.Create((int) opCode, modes);
        }

    }
}