using System;
using System.Collections.Generic;
using System.Linq;

namespace Codes.day7
{
    public partial class ComputeEngine
    {
        private int _savedInstruction;

        private int[] _savedProgram;

        public ComputeEngine()
        {
            InputData = new Queue<int>();
            OutputData = new List<int>();
        }

        public Queue<int> InputData { get; }
        public List<int> OutputData { get; }

        public int[] Run(int[] program, int instruction)
        {
            var preParseOpCode = program[instruction];
            var (opCode, modes) = _ParseOperationCode(preParseOpCode);
            switch (opCode)
            {
                case 99:
                    return program;
                case 1:
                    return Run(_Add(program, instruction, modes), instruction + 4);
                case 2:
                    return Run(_Multiply(program, instruction, modes), instruction + 4);
                case 3:
                    return Run(_Read(program, instruction), instruction + 2);
                case 4:
                    return Run(_Print(program, instruction, modes), instruction + 2);
                case 5:
                    return Run(program, _JumpIfTrue(program, instruction, modes));
                case 6:
                    return Run(program, _JumpIfFalse(program, instruction, modes));
                case 7:
                    return Run(_LessThan(program, instruction, modes), instruction + 4);
                case 8:
                    return Run(_Equals(program, instruction, modes), instruction + 4);
            }

            throw new Exception($"Unidentified Operation Code: {opCode}");
        }

        public int[] Continue()
        {
            return Run(_savedProgram, _savedInstruction);
        }

        public int GetOutput()
        {
            return OutputData.Last();
        }

        public void AddInput(int input)
        {
            InputData.Enqueue(input);
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