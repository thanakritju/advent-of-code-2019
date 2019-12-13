using System.Collections.Generic;
using System.Linq;

namespace Codes.day7
{
    public class IntCodeComputer
    {
        public List<ComputeEngine> Engines;

        public IntCodeComputer()
        {
            Engines = new List<ComputeEngine>();
        }

        public void AddEngine(ComputeEngine engine)
        {
            Engines.Add(engine);
        }

        public int GetOutputFromEngine()
        {
            return Engines.Last().OutputData.Last();
        }

        public int[] Run(int[] program, int arg1, int arg2)
        {
            program[1] = arg1;
            program[2] = arg2;

            return Engines.First().Run(program, 0);
        }


        public int[] Run(int[] program)
        {
            return Engines.First().Run(program, 0);
        }
    }
}