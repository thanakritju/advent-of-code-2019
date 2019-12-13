using System.Linq;
using Codes.day5;
using NUnit.Framework;

namespace Tests.day5
{
    public class SupervisionTerminalTest
    {
        private IntCodeComputer _computer;
        
        [SetUp]
        public void Setup()
        {
            _computer = new IntCodeComputer();
        }


        [TestCase(new[] {3, 0, 4, 0, 99}, 15, 15, new[] {15, 0, 4, 0, 99})]
        public void TestRunOperationCodeThreeAndFour(int[] program, int input, int output, int[] expectedProgram)
        {
            _computer.InputData.Enqueue(input);
            
            var outputProgram = _computer.Run(program);

            Assert.AreEqual(output, _computer.OutputData.First());
            Assert.AreEqual(expectedProgram, outputProgram);
        }
    }
}