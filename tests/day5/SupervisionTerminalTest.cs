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
        
        [TestCase(new[] {1002, 4, 3, 4, 33}, new[] {1002, 4, 3, 4, 99})]
        [TestCase(new[] {1101, 44, 55, 4, 33}, new[] {1101, 44, 55, 4, 99})]
        public void TestPositionAndImmediateMode(int[] program, int[] expectedProgram)
        {
            var outputProgram = _computer.Run(program);

            Assert.AreEqual(expectedProgram, outputProgram);
        }

        [Test]
        public void TestDay5Part1()
        {
            var input = 1;

            var intCodeComputer = Runner.SolveDay5Part1(input);
            
            Assert.AreEqual(15259545, intCodeComputer.OutputData.Last());
        }
    }
}