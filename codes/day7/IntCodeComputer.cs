using System;
using System.Collections.Generic;
using System.Linq;

namespace Codes.day7
{
    public class IntCodeComputer
    {
        private readonly List<ComputeEngine> _engines;

        public IntCodeComputer()
        {
            _engines = new List<ComputeEngine>();
        }

        public void AddEngine(ComputeEngine engine)
        {
            _engines.Add(engine);
        }

        public int GetOutputFromEngine()
        {
            return _engines.Last().GetOutput();
        }

        public int[] Run(int[] program, int arg1, int arg2)
        {
            program[1] = arg1;
            program[2] = arg2;

            return _engines.First().Run(program, 0);
        }

        public int[] Run(int[] program)
        {
            return _engines.First().Run(program, 0);
        }

        public void RunMultipleEnginesWithFeedbackLoop(int[] program, IEnumerable<int> phaseSetting)
        {
            _AddPhaseSetting(phaseSetting);

            const int inputEngine = 0;
            _engines[0].AddInput(inputEngine);

            for (var i = 0; i < _engines.Count; i++)
            {
                if (_engines[i].IsHalted) break;
                try
                {
                    if (_engines[i].IsStarted()) _engines[i].Continue();
                    else _engines[i].Run(program, 0);
                }
                catch (InvalidOperationException)
                {
                    // Ignore
                }

                if (i < _engines.Count - 1)
                {
                    _engines[i + 1].AddInput(_engines[i].GetOutput());
                }
                else
                {
                    _engines[0].AddInput(_engines[i].GetOutput());
                    i = -1;
                }
            }
        }

        private void _AddPhaseSetting(IEnumerable<int> possiblePhaseSetting)
        {
            var i = 0;
            foreach (var phaseInput in possiblePhaseSetting)
            {
                _engines[i].AddInput(phaseInput);
                i++;
            }
        }

        public override string ToString()
        {
            var output = "";
            foreach (var engine in _engines) output += $"Output data: {engine.OutputData.Last()}\n\n";
            return output;
        }
    }
}