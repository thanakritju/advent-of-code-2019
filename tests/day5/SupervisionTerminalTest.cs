using System.Linq;
using Codes.day5;
using NUnit.Framework;
using Runner = Codes.day5.Runner;

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


        [TestCase(new[] {3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8}, 8, 1)]
        [TestCase(new[] {3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8}, 9, 0)]
        [TestCase(new[] {3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8}, 8, 0)]
        [TestCase(new[] {3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8}, 7, 1)]
        [TestCase(new[] {3, 3, 1108, -1, 8, 3, 4, 3, 99}, 8, 1)]
        [TestCase(new[] {3, 3, 1108, -1, 8, 3, 4, 3, 99}, 9, 0)]
        [TestCase(new[] {3, 3, 1107, -1, 8, 3, 4, 3, 99}, 8, 0)]
        [TestCase(new[] {3, 3, 1107, -1, 8, 3, 4, 3, 99}, 7, 1)]
        [TestCase(new[] {3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9}, 0, 0)]
        [TestCase(new[] {3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9}, 1, 1)]
        [TestCase(new[] {3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1}, 0, 0)]
        [TestCase(new[] {3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1}, 1, 1)]
        [TestCase(new[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31,
            1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104,
            999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 7, 999)]
        [TestCase(new[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31,
            1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104,
            999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 8, 1000)]
        [TestCase(new[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31,
            1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104,
            999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 9, 1001)]
        public void TestSixthSeventhEighthAndNinthOperationCode(int[] program, int input, int output)
        {
            _computer.InputData.Enqueue(input);

            _computer.Run(program);

            Assert.AreEqual(output, _computer.OutputData.Last());
        }

        [Test]
        public void TestDay5Part1()
        {
            var input = 1;

            var intCodeComputer = Runner.SolveDay5Part1(input);

            Assert.AreEqual(15259545, intCodeComputer.OutputData.Last());
        }

        [Test]
        public void TestDay5Part2()
        {
            var input = 5;

            var intCodeComputer = Runner.SolveDay5Part2(input);

            Assert.AreEqual(7616021, intCodeComputer.OutputData.Last());
        }
    }
}