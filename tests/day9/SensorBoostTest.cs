using System.Linq;
using Codes.day9;
using NUnit.Framework;

namespace Tests.day9
{
    public class SensorBoostTest
    {
        private IntCodeComputer _computer;

        [SetUp]
        public void Setup()
        {
            _computer = new IntCodeComputer();
        }

        [TestCase(new long[] {109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99}, 99)]
        [TestCase(new long[] {1102, 34915192, 34915192, 7, 4, 7, 99, 0}, 1219070632396864)]
        [TestCase(new[] {104, 1125899906842624, 99}, 1125899906842624)]
        [TestCase(new long[] {1101, 3333, 2222, 1985, 109, 2000, 109, 19, 204, -34, 99}, 5555)]
        public void TestRun(long[] program, long expected)
        {
            _computer.Run(program);

            Assert.AreEqual(expected, _computer.OutputData.Last());
        }

        [TestCase(new long[] {1101, 2, 3, 0, 109, 7, 203, -6, 20001, 1, 0, -7, 204, -7, 99}, 100, 105)]
        public void TestRun(long[] program, int input, long expected)
        {
            _computer.InputData.Enqueue(input);

            _computer.Run(program);

            Assert.AreEqual(expected, _computer.OutputData.Last());
        }


        [Test]
        public void TestDay9Part1()
        {
            var output = Runner.SolveDay9Part1(1);

            Assert.AreEqual(2316632620, output);
        }

        [Test]
        public void TestDay9Part2()
        {
            var output = Runner.SolveDay9Part1(2);

            Assert.AreEqual(78869, output);
        }
    }
}