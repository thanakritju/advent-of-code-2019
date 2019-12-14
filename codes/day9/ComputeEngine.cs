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

            try
            {
                while (true)
                {
                    var preParseOpCode = program[index];
                    var (opCode, modes) = _ParseOperationCode(preParseOpCode);
                    switch (opCode)
                    {
                        case 99:
                            return program;
                        case 1:
                            program = _Add(program, index, modes);
                            index += 4;
                            break;
                        case 2:
                            program = _Multiply(program, index, modes);
                            index += 4;
                            break;
                        case 3:
                            program = _Read(program, index, modes);
                            index += 2;
                            break;
                        case 4:
                            program = _Print(program, index, modes);
                            index += 2;
                            break;
                        case 5:
                            index = _JumpIfTrue(program, index, modes);
                            break;
                        case 6:
                            index = _JumpIfFalse(program, index, modes);
                            break;
                        case 7:
                            program = _LessThan(program, index, modes);
                            index += 4;
                            break;
                        case 8:
                            program = _Equals(program, index, modes);
                            index += 4;
                            break;
                        case 9:
                            program = _AdjustRelativeBase(program, index, modes);
                            index += 2;
                            break;
                        default:
                            throw new Exception($"Unidentified Operation Code: {opCode}");
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return _Run(_AllocateMoreMemory(program), index);
            }
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